using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private List<GameObject> waypoints;

    private int cursor;

	// Use this for initialization
	void Start () {
        cursor = 0;
	}

    public void Next() {
        if (cursor < waypoints.Count) {
            cursor++;
            StartCoroutine(moveToNextPoint());
        }
    }

    IEnumerator moveToNextPoint() {
        while (transform.position != waypoints[cursor].transform.position) {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[cursor].transform.position, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }


}
