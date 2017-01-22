﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTransition : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private List<GameObject> waypoints;

	[SerializeField]
    private int cursor;

    [SerializeField]
    private AudioClip beep;

	// Use this for initialization
	void Start () {
        cursor = -1;
		Next ();
	}

    public void Next() {
		if (cursor + 1 < waypoints.Count) {
			cursor++;
			StartCoroutine (moveToNextPoint ());
		} else if (cursor + 1 == waypoints.Count - 1) {
            GameObject.Find("Joueur").GetComponent<JoueurBehaviour>().CanMove = false;
            StartCoroutine(endSFX());
		} else {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator endSFX() {
        AudioSource asou = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        float x = 0.5f;
        while (asou.volume > 0.0f) {
            x -= Time.deltaTime * 0.5f;
            asou.volume = Mathf.Lerp(0.0f, 0.5f, x);
            yield return new WaitForEndOfFrame();
        }
        asou.clip = null;
        asou.volume = 0.0f;
        asou.PlayOneShot(beep);
        yield return new WaitForSeconds(5f);
        while (asou.volume < 0.3f) {
            x += Time.deltaTime * 0.5f;
            asou.volume = Mathf.Lerp(0.0f, 0.5f, x);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator moveToNextPoint() {
        while (transform.position != waypoints[cursor].transform.position) {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[cursor].transform.position, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
		JoueurBehaviour jb = GameObject.FindGameObjectWithTag ("Player").GetComponent<JoueurBehaviour> ();
		if (cursor % 2 == 1) {
			jb.LaunchPlayer ();
			waypoints [cursor].GetComponent<LevelsManager> ().launchLevel ();
		} else {
			jb.StopPlayer ();
			StartCoroutine(GameObject.FindGameObjectWithTag ("CanvasBen").GetComponentInChildren<ShowText> ().showNextText ());
			GetComponent<JoueurConfigLevelManager> ().changeConf (cursor / 2);
		}
    }




}
