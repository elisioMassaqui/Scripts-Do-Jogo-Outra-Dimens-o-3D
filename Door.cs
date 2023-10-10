using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

//	public Animator anim;
	public GameObject sensor;
	public GameObject Porta;


	void Start()
	{
		Porta.SetActive (true);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Player")
			Porta.SetActive (false);
	}

	void OnTriggerExit (Collider other)
	{
		if (other.transform.tag == "Player") { 

			Porta.SetActive (true);
		}
	}

}
