using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	 EnemyMovement ativarboolSeguir;


	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy") {
			ativarEnemies (true);
			
		} 

	}
	void ativarEnemies(bool ativar)
	{
//		ativarboolSeguir.seguindoPlayer = ativar;
	}


}
