using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class todaparedeDetected : MonoBehaviour {

	private Rigidbody rb;
	private destruirtodaParede bd;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bd = GetComponentInParent<destruirtodaParede> ();
	}

	public void getdown()
	{
		bd.destroyPart (rb);
	}
	
}
