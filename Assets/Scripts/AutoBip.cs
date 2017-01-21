using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBip : MonoBehaviour {

    private States state;

    [SerializeField]
    private AudioClip beep;

    [SerializeField]
    private AudioClip heart1;

    [SerializeField]
    private AudioClip heart2;

    [SerializeField]
    private float speed;

    private float stop = 1;

    private enum States {
        IDLE,
        DROPPING,
        CLIMBBACK
    }

    [SerializeField]
    private float upTime;

    [SerializeField]
    private float cooltime;
    [SerializeField]
    private float currentCooltime;
    [SerializeField]
    private float currentUptime;

    public bool firstUp;

    private bool currentlyUp;

    void Start() {
        state = States.IDLE;
        firstUp = true;
        currentCooltime = cooltime;
        currentUptime = upTime;
        currentlyUp = false;
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

    void Update() {


        if (currentCooltime > 0) {
            currentCooltime -= Time.deltaTime;
        } else if (currentCooltime < 0 && currentUptime > 0) {
            currentlyUp = true;
            currentUptime -= Time.deltaTime;
        } else if (currentCooltime < 0 && currentUptime < 0) {
            currentCooltime = cooltime;
            currentUptime = upTime;
            currentlyUp = false;
        }

        Vector3 move = new Vector3();
        move.x = Time.deltaTime * speed * stop;

        if (currentlyUp && firstUp && state != States.CLIMBBACK) {
            PlayBeep();
            PlayHeart1();
            firstUp = false;
        } else if (!currentlyUp && !firstUp) {
            firstUp = true;
            PlayHeart2();
        }


        if (currentlyUp && state != States.CLIMBBACK ) {
            move.y += 0.1f;
            state = States.DROPPING;
        } else if (state == States.DROPPING) {
            Vector3 drop = new Vector3();
            drop.y = transform.position.y;
            transform.position -= 2 * drop;
            state = States.CLIMBBACK;
        } else if (state == States.CLIMBBACK) {
            Vector3 back = new Vector3();
            back.y = transform.position.y / 6;
            transform.position -= back;
            if (transform.position.y < .05f && transform.position.y > -.05f)
                state = States.IDLE;
        }
        if (transform.position.y > 4.5 || transform.position.y < -4.5)
            move.y = 0f;
        transform.position += move;
    }

    public void StopPlayer() {
        stop = 0;
    }

    public void LaunchPlayer() {
        stop = 1;
    }
}
