using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportar : MonoBehaviour {

	public GameObject text3D; //Texto que aparece na area de teletransporte
	public GameObject objToTP; //Objecto que será teletransportado nesse caso o Player
	public Transform tploc; //Localização.

	// Use this for initialization
	void Start () {

		text3D.SetActive (false);
		
	}
	
	void OnTriggerStay(Collider other)
	{
		text3D.SetActive (true);
		if((other.gameObject.tag == "Player") && Input.GetKey(KeyCode.T)) //Se objecto colidir com outro objecto que possui tag Player e a tecla T estiver pressionada.
			objToTP.transform.position = tploc.transform.position; //Então o Objecto com Player recebe a posição do Object de Teleport
	}

	void OnTriggerExit()
	{
		text3D.SetActive (false);
	}
}
