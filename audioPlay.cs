using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour {

	public AudioSource forLevel2; //Audio do tunel do Level2
	public GameObject colisor;  //Gatilho trigger pra tocar audio.

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider audio)
	{
		if (audio.transform.tag == "Player") //Se o objecto com tag Player entrar no gatilho.
		{

			forLevel2.Play (); //Começa tocar o audio.
			Destroy (colisor,2f); //E o gatilho trigger destoi depois de 2f segundos, no caso de entrar lá de novo a musica vai se repetir imediatamente.(Pra evitar tocar musica de novo várias vezes).
		}
	}
}
