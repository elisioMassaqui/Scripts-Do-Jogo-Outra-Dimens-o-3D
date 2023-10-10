using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirtodaParede : MonoBehaviour {

	public List<Rigidbody> rbs;
	public  int numDestroy;

	public void destroyPart(Rigidbody rb)
	{
		rb.isKinematic = false;
		numDestroy -= 1;
		if (numDestroy < 0) {

			for (int i = 0; i < rbs.Count; i++) {
				rbs [i].isKinematic = false;
			}
		}
	}
}
