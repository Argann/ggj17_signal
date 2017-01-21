using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour {
	public GameObject letter;
	public GameObject myCollider;
	private GameObject parent;
	// Use this for initialization
	void Start () {
		parent = GameObject.FindGameObjectWithTag ("Canvas");
		// Instanciation d'une lettre
		Vector3 posLetter = parent.transform.position;
		posLetter.x += 200;
		posLetter.y += 100;
		GameObject instanciatedLetter = Instantiate (letter, posLetter, new Quaternion (), parent.transform);
		letter.GetComponent<Text>().text = "A";

		// Instanciation du collider associe
		Vector3 posCollider = new Vector3(-2.36f, 0.19f, 0f);
		posCollider.x += 200 * .0313f;
		posCollider.y += 100 * .0313f;
		GameObject instanciatedCollider = Instantiate (myCollider, posCollider, new Quaternion ());
		instanciatedCollider.GetComponent<LetterCollider> ().boundLetter = instanciatedLetter;
	}

	// Update is called once per frame
	void Update () {
	}
}
