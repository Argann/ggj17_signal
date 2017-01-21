using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour {

    private bool started = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && !started) {
            StartCoroutine(startShort());
            started = true;
        }
	}

    IEnumerator startShort() {
        GetComponent<JoueurBehaviour>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<JoueurBehaviour>().CanMove = false;
        AudioSource asource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        float t = 0.5f;
        asource.volume = 0.5f;

        while (asource.volume > 0.0f) {
            asource.volume = Mathf.Lerp(0.0f, 0.5f, t);
            t -= Time.deltaTime * 0.5f;
            yield return new WaitForEndOfFrame();
        }

        GameObject go = GameObject.Find("MAINTEXT");
        Text text = go.GetComponent<Text>();
        go.GetComponent<AlphaBlink>().enabled = false;

        float x = text.color.a;

        while (text.color.a > 0.0f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(0.0f, 0.5f, x));
            x -= Time.deltaTime * 0.5f;
            yield return new WaitForEndOfFrame();
        }
    }
}
