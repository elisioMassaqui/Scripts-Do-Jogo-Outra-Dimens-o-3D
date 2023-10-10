using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirParede : MonoBehaviour {

	private Rigidbody rb;
	public float damagedWeed;

	public void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	public void Damage(float i)
	{
		damagedWeed -= 1;
		if (damagedWeed <= 0) {
			rb.isKinematic = false;
		}
	}
}
