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
    [Range(0f, 1f)]
    private float cooldown;

    [SerializeField]
    private float waitBeforeStart;

	[SerializeField]
	private float waitBeforeEnd;

	// Use this for initialization
	void Start () {
		objet = GetComponent<Text> ();
	}

    public IEnumerator showNextText() {
        yield return new WaitForSeconds(waitBeforeStart);
		foreach (char ch in texts[current]) {
            objet.text += ch;
            yield return new WaitForSeconds(cooldown);
        }
		yield return new WaitForSeconds(waitBeforeEnd);
		objet.text = "";
		current++;
		Camera.main.GetComponent<CameraTransition> ().Next ();
    }
}
