using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowText : MonoBehaviour {

	[SerializeField]
	public string[] texts;

    private Text objet;
	private int current = 0 ;

    [SerializeField]
    private bool launchAtStart;

    [SerializeField]
    [Range(0f, 1f)]
    private float cooldown;

    [SerializeField]
    private float waitBeforeStart;

	[SerializeField]
	private float waitBeforeEnd;

	// Use this for initialization
	void Start () {
		objet = GetComponent<Text> ();
        if (launchAtStart) {
            texts = new string[1];
            texts[0] = objet.text;
            objet.text = "";
            StartCoroutine(showNextText());
        }
	}

    public IEnumerator showNextText() {
        yield return new WaitForSeconds(waitBeforeStart);
		foreach (char ch in texts[current]) {
			if (ch == '+')
				objet.text += "\n";
			else
            	objet.text += ch;
            yield return new WaitForSeconds(cooldown);
        }
		yield return new WaitForSeconds(waitBeforeEnd);
        if (!launchAtStart) InvokeRepeating("blinkCursor", 0, 1);
		StartCoroutine(waitForInput());
    }

    public IEnumerator waitForInput() {
        while (!Input.anyKey) yield return new WaitForEndOfFrame();
        if (!launchAtStart) {
            objet.text = "";
            current++;
            Camera.main.GetComponent<CameraTransition>().Next();
        }
        yield return new WaitForEndOfFrame();
        CancelInvoke();
    }

    private static string blinkingChar = "\n_";

    void blinkCursor() {
        try {
            string last_char = objet.text.Substring(objet.text.Length - blinkingChar.Length);
            if (last_char == blinkingChar) objet.text = objet.text.Remove(objet.text.Length - blinkingChar.Length);
            else objet.text += blinkingChar;
        } catch(Exception e) {}
    }
}
