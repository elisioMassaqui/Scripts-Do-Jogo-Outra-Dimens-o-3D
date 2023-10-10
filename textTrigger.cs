using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTrigger : MonoBehaviour {


	//[Script pra instanciar dialogos ou Quests]

	public GameObject uiObject; //Object a ser Ativado.
	// Use this for initialization
	void Start () {

		uiObject.SetActive (false);
		
	}
	
	// Update is called once per frame

	void OnTriggerEnter (Collider Apenasplayer)
	{
		
		if (Apenasplayer.gameObject.tag == "Player") //Se o object definido pra apresentar dialogo de texto ou algum Quests colidir com Player ,nesse caso, com um GameObject que tem a Tag Player então ativa o Object 
		{
			uiObject.SetActive (true); //Ativado depois da condição.
			StartCoroutine ("WaitForSec"); //A funçao a baixo relacionada ao Object.
			Debug.Log ("First TXT");
		}
		
	}

	//Essa é a função a baixo,estavas a procurar aonde? hammm???
	IEnumerator WaitForSec()
	{
		yield return new WaitForSeconds (20); //Esperar por 10 segundos.
		Destroy (uiObject);  //E depois destruir o texto.
		Destroy (gameObject); //E destruir o GameObject da colisão.
	}
}
