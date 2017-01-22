﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoueurConfigLevelManager : MonoBehaviour {

	JoueurBehaviour joueurbehaviour ;
	TrailRenderer trailRenderer ;
	Text textObjet ;

	[SerializeField]
	List<Color> colors ;

	[SerializeField]
	List<float> speeds ;

	void Start(){
		textObjet = GameObject.FindGameObjectWithTag ("CanvasBen").GetComponentInChildren<Text> ();
		joueurbehaviour = GameObject.FindGameObjectWithTag ("Player").GetComponent<JoueurBehaviour> ();
		trailRenderer = GameObject.FindGameObjectWithTag ("Player").GetComponent<TrailRenderer> ();
	}

	// Update is called once per frame
	public void changeConf(int current){
		joueurbehaviour.speed = speeds[current];
		textObjet.color = colors [current];
		trailRenderer.startColor = colors [current];
		trailRenderer.endColor = colors [current];
	}
}
