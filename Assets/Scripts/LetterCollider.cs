using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCollider : MonoBehaviour {
	public GameObject letter;
	private GameObject instanciedLetter;
	public string value;
	private GameObject parent;

	void Start () {
		parent = GameObject.FindGameObjectWithTag ("Canvas");
		// Instanciation d'une lettre
		Vector3 pos = parent.transform.position;
		instanciedLetter = Instantiate (letter, transform.position, new Quaternion (), parent.transform);
		instanciedLetter.GetComponent<Text>().text = value;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (instanciedLetter);
		Destroy (gameObject);
	}
}
