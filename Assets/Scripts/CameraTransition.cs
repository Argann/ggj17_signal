﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private List<GameObject> waypoints;

	[SerializeField]
    private int cursor;

	// Use this for initialization
	void Start () {
        cursor =-1;
		Next ();
	}

    public void Next() {
		if (cursor + 1 < waypoints.Count) {
			cursor++;
			StartCoroutine (moveToNextPoint ());
		} else {
			Debug.Log ("the end");
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
