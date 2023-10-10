using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textriggerStay : MonoBehaviour {


	//[Script pra instanciar dialogos ou Quests]

	public GameObject uiObject; //Object a ser Ativado.
	public float tempFalar = 0f;
	public Animator npc;
	// Use this for initialization
	void Start () {

		uiObject.SetActive (false);
		npc.SetBool ("Skeleton Ofensive", false);
		npc.SetBool ("emily open door", false);

	}

	// Update is called once per frame

	void OnTriggerStay (Collider Apenasplayer)
	{

		if (Apenasplayer.gameObject.tag == "Player") { //Se o object definido pra apresentar dialogo de texto ou algum Quests colidir com Player ,nesse caso, com um GameObject que tem a Tag Player então ativa o Object 
//			StartCoroutine ("Falar");
			uiObject.SetActive (true);
			npc.SetBool ("Skeleton Ofensive", true);
			npc.SetBool ("emily open door", true);
		} 
	}
//	IEnumerator Falar()
//	{
//		yield return new WaitForSeconds (tempFalar);
//		uiObject.SetActive (true); //Ativado depois da condição.
//
//	}

	void OnTriggerExit()
	{
		uiObject.SetActive (false); //Se o Player sair da area de colisão então desativa o Texto.
		npc.SetBool ("Skeleton Ofensive", false);
		npc.SetBool ("emily open door", false);
	}
}
