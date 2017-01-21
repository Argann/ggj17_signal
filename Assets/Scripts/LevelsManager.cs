using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour {

	private List<GameObject> lettersWaypoint = new List<GameObject>();
	private bool isFinished = false;

	private GameObject player;
		
	[SerializeField]
	public GameObject playerBegin;

	private float player_end_X = float.NegativeInfinity ;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//this.launchLevel ();
		LetterCollider[] lettersColider = GetComponentsInChildren<LetterCollider> ();
		foreach (LetterCollider letterColider in lettersColider) {
			lettersWaypoint.Add (letterColider.gameObject);
			if (player_end_X < letterColider.gameObject.transform.position.x) {
				player_end_X = letterColider.gameObject.transform.position.x;
			}
		}
		player_end_X += 1;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject letter in lettersWaypoint) {
			if (letter == null) {
				lettersWaypoint.Remove (letter);
				break;
			}
		}

		if (player.transform.position.x > player_end_X)
			finishLevel ();

	}

	public void finishLevel(){
		if (!isFinished) { 
			if (lettersWaypoint.Count == 0) {//Next Level
				isFinished = true;
				Camera.main.GetComponent<CameraTransition> ().Next ();
			} else { //relaunch
				launchLevel ();
			}
		}
	}

	public void launchLevel(){
		player.GetComponent<TrailRenderer> ().Clear ();
		player.transform.position = playerBegin.transform.position;
	}

}
 	