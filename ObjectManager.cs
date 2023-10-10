using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	public GameObject objectos;
	public float spawnTime = 3f; //Entrevalo de tempo em que os Enemy's aparecem do mapa.
	public Transform[] spawnPoints; //Posição do aparecimento de GameObject ou inimigo que nesse caso também é uma GameObject kkkkkkkkkk.

	private float timer;
	private int spawned = 0;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{           
		// If the player has no health left...
		if (Input.GetKey(KeyCode.Space))
		{
			// ... exit the function.
			return;
		}

		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

		Instantiate (objectos, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}