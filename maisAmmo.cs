using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maisAmmo : MonoBehaviour {

	hit Munin;
	public int boxAmmo = 30;

	// Use this for initialization
	void Start () {

		Munin = GetComponent<hit> ();
		
	}
	
	void OnTriggerEnter(Collider munin)
	{
		if (munin.transform.tag == "Player" && Input.GetKey (KeyCode.E))
			Munin.pistolAmmo += boxAmmo;
			print ("moreAmmo");
			
			
	}
}
