using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour {

	public GameObject blackDoor; //Porta Preta do Nível 2.5
	public float  timePorta = 840f; //Tempo de destruir a porta após sair do trigger

	// Use this for initialization
	void Start () {

		blackDoor.SetActive (false); //Desativar a porta preta no primeiro Frame
		
	}

	void OnTriggerEnter(Collider fechar)
	{
		{
		if (fechar.transform.tag == "Player")
			blackDoor.SetActive (true); //Se entrar na colsão trigger então a porta preta aparece.
		}
}
	void OnTriggerExit(Collider fechar)
	{
		if (fechar.transform.tag == "Player")
		{
			StartCoroutine ("destruirPorta"); //Se sair do gatilho trigger então o temporizador pra destruir a porta começa a contar.
		}
	}
	IEnumerator destruirPorta() //Método de contagem pra fazer alguma ação
	{
		yield return new WaitForSeconds(timePorta); //Chamar a variável com tempo de destruição.
		Destroy(blackDoor); //Destruir a porta.
	}
}
