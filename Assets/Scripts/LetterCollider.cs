using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCollider : MonoBehaviour {
	public GameObject letter;
	private GameObject instanciedLetter;
	public string value;
	private GameObject parent;
	[SerializeField]
	private GameObject particles;

	void Start () {
		parent = GameObject.FindGameObjectWithTag ("Canvas");
		// Instanciation d'une lettre
		Vector3 pos = parent.transform.position;
		instanciedLetter = Instantiate (letter, pos, new Quaternion (), parent.transform);
		instanciedLetter.transform.position = transform.position;
		//instanciedLetter.AddComponent<AlphaBlink>();
		instanciedLetter.GetComponent<Text>().text = value;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Instantiate (particles, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent);
		Destroy (instanciedLetter);
		Destroy (gameObject);
	}
}
