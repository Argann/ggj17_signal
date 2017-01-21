using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurBehaviour : MonoBehaviour {
	private States state;
	private enum  States {
		IDLE,
		DROPPING,
		CLIMBBACK
	}
	void Start () {
		state = States.IDLE;
	}

	void Update () {
		Vector3 move = new Vector3 ();
		move.x = Time.deltaTime;
		if (Input.GetAxisRaw ("Up&Down") > 0) {
			move.y += 0.1f;
			state = States.DROPPING;
		} else if (state == States.DROPPING) {
			Vector3 drop = new Vector3 ();
			drop.y = transform.position.y;
			transform.position -= 2 * drop;
			state = States.CLIMBBACK;
		} else if (state == States.CLIMBBACK) {
			Vector3 back = new Vector3 ();
			back.y = .1f * Mathf.Sign(transform.position.y);
			transform.position -= back;
			if ( transform.position.y < .1f && transform.position.y > -.1f)
				state = States.IDLE;
		}
		if (transform.position.y > 4.5 || transform.position.y < -4.5)
			move.y = 0f;
		transform.position += move;
	}
}
