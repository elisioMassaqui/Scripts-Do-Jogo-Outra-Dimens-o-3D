using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour {

	public EnemyMovement[] inimigos;
//	EnemyMovement inimigoMovement;

	void Start()
	{
//		inimigoMovement = GetComponent<EnemyMovement> ();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {

			SetEnemies (true);

		}
	}


	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			SetEnemies (false);
		}
	}
	void SetEnemies(bool state)
	{
		for (int i = 0; i < inimigos.Length; i++)
		{

//			inimigos[i].seguindoPlayer = state;
		}
	}
}
