using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;  //Posição do jogador.
	PlayerHealth playerHealth; //Vida do jogador.
	EnemyHealth  enemyHealth; //Vida do Enemy.
	NavMeshAgent nav;   //Componente inteligente de navegação do Enemy no Mapa.
//	Vector3 startPosition;  //A primeira posição do Enemy no mundo
//	public bool seguindoPlayer; //Pra ativar na hora de seguir o Player.
	Animator anim;

	// Use this for initialization
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform; //Recebe as propriedades físicas do objecto com Tag  "Player" nesse caso a posição.
		playerHealth = player.GetComponent <PlayerHealth> (); //Pegar componente do script da vida do pLayer.
		enemyHealth = GetComponent <EnemyHealth> (); //Pegar componentes do script da vida do Enemy.
		nav = GetComponent <NavMeshAgent> (); //Pegar componente da inteligencia artificial de navegação de Object no Mapa.
		anim = GetComponent<Animator>();  //Pegar componentes do controle da animação e suas anims.
//		startPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		//Se o progresso de vida do inimigo e do Player foi maior que zero!
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
		
			//Então navega no Mapa procurando o Player.
		nav.SetDestination (player.position);
//			anim.SetBool ("enemyFollow", false); //Animação de idle desativada quando não está seguindo o Player e vai automaticamente pra animação de movemente.
	}

		//Se não então para de procurar ou navegar.
		else 
		{

		nav.enabled = false;

//			nav.SetDestination (startPosition); //Voltar para posição inicial
//			anim.SetBool ("enemyFollow", true); //Sai da animação de movement para ativar animação de idle.
	  	}
  	}

}
