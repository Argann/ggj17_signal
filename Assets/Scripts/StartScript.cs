using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
