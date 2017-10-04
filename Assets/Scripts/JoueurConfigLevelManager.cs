using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoueurConfigLevelManager : MonoBehaviour {

	JoueurBehaviour joueurbehaviour ;
	TrailRenderer trailRenderer ;
	Text textObjet ;
	SpriteRenderer spriteRenderer ;

	[SerializeField]
	List<Color> colors ;

	[SerializeField]
	List<float> speeds ;

	void Start(){
		textObjet = GameObject.FindGameObjectWithTag ("CanvasBen").GetComponentInChildren<Text> ();
		joueurbehaviour = GameObject.FindGameObjectWithTag ("Player").GetComponent<JoueurBehaviour> ();
		trailRenderer = GameObject.FindGameObjectWithTag ("Player").GetComponent<TrailRenderer> ();
		spriteRenderer = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	public void changeConf(int current){
		joueurbehaviour.speed = speeds[current];//speed
		textObjet.color = colors [current];//text
		trailRenderer.startColor = colors [current];//trace
		trailRenderer.endColor = colors [current]; //trace
		spriteRenderer.color = colors [current]; //cursor
	}
}
