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
		Vector3 pos = parent.transform.position;
		GameObject instanciatedLetter = Instantiate (letter, pos, new Quaternion (), parent.transform);
		letter.GetComponent<Text>().text = "A";

		// Instanciation du collider associe
		GameObject instanciatedCollider = Instantiate (myCollider, pos, new Quaternion ());
		instanciatedCollider.GetComponent<LetterCollider> ().BoundLetter = instanciatedLetter;
	}

	// Update is called once per frame
	void Update () {
	}
}
