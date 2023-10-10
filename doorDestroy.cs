using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorDestroy : MonoBehaviour {

	public int timeDestruirObj = 70;
	public int timeSound = 90;
	public GameObject objectoDestruir;
	public GameObject destroySound;

	// Use this for initialization
	void Start () {

		StartCoroutine ("timeDestroy");

	}

	IEnumerator timeDestroy()
	{
		yield return new WaitForSeconds (timeDestruirObj);
		Destroy (objectoDestruir);
		yield return new WaitForSeconds (timeSound);
		Destroy (destroySound);

	}

}