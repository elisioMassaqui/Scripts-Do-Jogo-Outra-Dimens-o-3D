using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorActive : MonoBehaviour {

	public GameObject door; //Porta do tunel.

	// Use this for initialization
	void Start () {
		door.SetActive (true); //Ativar porta do tunel no primeiro frame.
		
	}
		
	
	void OnTriggerEnter(Collider porta)
	{
		if (porta.transform.tag == "Player")
			door.SetActive (false);  //Se o Player ou Objecto com tag Player entrar no GameObject com gatilho trigger,então desativa a porta, ou seja abre.
			
	}
	void OnTriggerExit(Collider porta)
	{
		if (porta.transform.tag == "Player")//Se o Player ou Objecto com tag Player sair no GameObject com gatilho trigger.
			StartCoroutine ("tempoPorta"); //Então o temporizador pra fechar a porta começa a contar.
	}
		
	IEnumerator tempoPorta()
	{
		yield return new WaitForSeconds (10f); //Depois de 10f segundos.
		door.SetActive (true); //A porta é ativada.
	}

}
