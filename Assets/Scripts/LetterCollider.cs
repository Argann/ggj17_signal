using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCollider : MonoBehaviour {
	private GameObject boundLetter;
	public GameObject BoundLetter {
		set { boundLetter = value; }
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (boundLetter);
		Destroy (gameObject);
	}
}
