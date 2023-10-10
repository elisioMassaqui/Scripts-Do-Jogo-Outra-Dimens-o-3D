using UnityEngine;
using System.Collections;
    public class EnemyManager : MonoBehaviour 
    {
        public PlayerHealth playerHealth;
        public GameObject enemy;
        public float spawnTime = 3f; //Entrevalo de tempo em que os Enemy's aparecem do mapa.
        public Transform[] spawnPoints; //Posição do aparecimento de GameObject ou inimigo que nesse caso também é uma GameObject kkkkkkkkkk.
		public int CancelarSpawn = 7;
        private float timer;
        private int spawned = 0;

        void Start ()
        {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }
		
		void Update()
		{
		 StartCoroutine ("Cancelar");

		}

        void Spawn ()
        {           
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
	IEnumerator Cancelar()
	{
		yield return new WaitForSeconds (CancelarSpawn);
		CancelInvoke("Spawn");

	}
		
 }