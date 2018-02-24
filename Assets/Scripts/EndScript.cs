using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    [SerializeField]
    private Image black;

    private AudioSource asou;

    [SerializeField]
    private bool endScene2;

    private float wait;

    void Start() {
        black.color = new Color(black.color.r, black.color.g, black.color.b, 0.0f);
        StartCoroutine(endCredits());
        asou = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
	
	IEnumerator endCredits() {
        if (endScene2) {
            yield return new WaitForSeconds(10f);
        } else {
            yield return new WaitForSeconds(18f);
        }
        
        float x = black.color.a;

        while (black.color.a < 1.0f) {
            black.color = new Color(black.color.r, black.color.g, black.color.b, Mathf.Lerp(0.0f, 1f, x));
            x += Time.deltaTime * 0.5f;
            asou.volume = Mathf.Lerp(0.0f, 1f, 1f-x);
            yield return new WaitForEndOfFrame();
        }

        if (endScene2) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(3);
        }
    }
}
