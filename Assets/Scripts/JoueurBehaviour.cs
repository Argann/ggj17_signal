using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurBehaviour : MonoBehaviour {
	private States state;

    [SerializeField]
    private AudioClip beep;

    [SerializeField]
    private AudioClip heart1;

    [SerializeField]
    private AudioClip heart2;

    [SerializeField]
    public float speed;

	private float stop = 1 ;

	private enum  States {
		IDLE,
		DROPPING,
		CLIMBBACK
	}

    [SerializeField]
    private bool canMove;

    public bool CanMove {
        get { return canMove; }
        set { canMove = value; }
    }


    public bool firstUp;

    void Start () {
		state = States.IDLE;
        firstUp = true;
	}

    void PlayBeep() {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(beep);
    }

    void PlayHeart1() {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(heart1);
    }

    void PlayHeart2() {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(heart2);
    }

    void Update () {

		Vector3 move = new Vector3 ();
		move.x = Time.deltaTime * speed * stop;

        if (Input.GetAxisRaw("Up&Down") > 0 && firstUp && state != States.CLIMBBACK && CanMove) {
            PlayBeep();
            PlayHeart1();
            firstUp = false;
        } else if (Input.GetAxisRaw("Up&Down") == 0 && !firstUp) {
            firstUp = true;
            PlayHeart2();
        }


		if (Input.GetAxisRaw ("Up&Down") > 0 && state != States.CLIMBBACK && CanMove) {
			move.y += 0.1f;
			state = States.DROPPING;
		} else if (state == States.DROPPING) {
			Vector3 drop = new Vector3 ();
			drop.y = transform.position.y;
			transform.position -= 2 * drop;
			state = States.CLIMBBACK;
		} else if (state == States.CLIMBBACK) {
			Vector3 back = new Vector3 ();
			back.y = transform.position.y /6;
			transform.position -= back;
			if ( transform.position.y < .05f && transform.position.y > -.05f)
				state = States.IDLE;
		}
		if (transform.position.y > 4.5) {
			move.y = 0f;
			Vector3 drop = new Vector3 ();
			drop.y = transform.position.y;
			transform.position -= 2 * drop;
			state = States.CLIMBBACK;
		}
		transform.position += move;
	}

	public void StopPlayer(){
		stop = 0;
	}

	public void LaunchPlayer(){
		stop = 1;
	}
}
