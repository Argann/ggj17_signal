using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCollider : MonoBehaviour {
	public GameObject boundLetter;

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (boundLetter);
		Destroy (gameObject);
	}
}
