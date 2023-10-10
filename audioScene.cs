using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScene : MonoBehaviour {


	public AudioSource fortMercer;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider audioCena)
	{
		if (audioCena.transform.tag == "Player") {
			fortMercer.Play();
		}
	}

	void OnTriggerExit(Collider audioCena)
	{
		if (audioCena.transform.tag == "Player") {
			fortMercer.Stop ();
		}
	}
}
