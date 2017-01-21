using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AlphaBlink : MonoBehaviour {

    [SerializeField]
    private float minAlpha = 0.3f;

    [SerializeField]
    private float maxAlpha = 1.0f;

    [SerializeField]
    private bool isPlayer;

    private SpriteRenderer player;

    private Text text;

    [SerializeField]
    private float speed = 5;

	// Use this for initialization
	void Start () {
        if (isPlayer) {
            player = GetComponent<SpriteRenderer>();
            player.color = new Color(player.color.r, player.color.g, player.color.b, minAlpha);
        } else {
            text = GetComponent<Text>();
            text.color = new Color(text.color.r, text.color.g, text.color.b, minAlpha);
        }
        StartCoroutine(blinkAlpha());
	}

    IEnumerator blinkAlpha() {
        float t = 0.0f;
        if (isPlayer) {
            while (true) {
                while (player.color.a < maxAlpha) {
                    player.color = new Color(player.color.r, player.color.g, player.color.b, Mathf.Lerp(minAlpha, maxAlpha, t));
                    t += Time.deltaTime * speed;
                    yield return new WaitForEndOfFrame();
                }
                while (player.color.a > minAlpha) {
                    player.color = new Color(player.color.r, player.color.g, player.color.b, Mathf.Lerp(minAlpha, maxAlpha, t));
                    t -= Time.deltaTime * speed;
                    yield return new WaitForEndOfFrame();
                }
            }
        } else {
            while (true) {
                while (text.color.a < maxAlpha) {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(minAlpha, maxAlpha, t));
                    t += Time.deltaTime * speed;
                    yield return new WaitForEndOfFrame();
                }
                while (text.color.a > minAlpha) {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(minAlpha, maxAlpha, t));
                    t -= Time.deltaTime * speed;
                    yield return new WaitForEndOfFrame();
                }
            }
        }
    }
}
