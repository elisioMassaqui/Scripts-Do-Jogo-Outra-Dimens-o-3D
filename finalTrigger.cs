using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerStay(Collider pf)
	{
		if(pf.transform.tag == "Player" && Input.GetKey(KeyCode.E))
		{
			Application.LoadLevel ("Credits");
		}
			
	}

}
