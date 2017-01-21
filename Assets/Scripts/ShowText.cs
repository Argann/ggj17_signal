using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowText : MonoBehaviour {

    private string text;

    private Text objet;

    [SerializeField]
    [Range(0f, 1f)]
    private float cooldown;

    [SerializeField]
    private float waitBeforeStart;

	// Use this for initialization
	void Start () {
        objet = GetComponent<Text>();
        text = objet.text;
        objet.text = "";
        StartCoroutine(showText());
	}

    IEnumerator showText() {
        yield return new WaitForSeconds(waitBeforeStart);
        foreach (char ch in text) {
            objet.text += ch;
            yield return new WaitForSeconds(cooldown);
        }
    }
}
