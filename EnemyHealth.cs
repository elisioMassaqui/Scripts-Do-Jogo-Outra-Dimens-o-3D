using UnityEngine;

    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 100; //Vida do inicio
	    public int currentHealth; //Progresso da vida.
        public float sinkSpeed = 2.5f;
        public int scoreValue = 10; //Valor das pontuações.
        public AudioClip deathClip; //Audio de morte do Zombie.

        Animator anim; //Controle de animação.
        AudioSource enemyAudio;
        ParticleSystem hitParticles;
        CapsuleCollider capsuleCollider;
        EnemyMovement enemyMovement; //Aqui pegamos os componentes do script do movimento do inimigo pra serem usados aqui.
		bool IsDead; //Verdadeiro ou falso sobre a morte do inimigo.
		bool isSinking;

        void Awake ()
        {
            anim = GetComponent <Animator> (); //Pegar os componentes do Controle de animação
            enemyAudio = GetComponent <AudioSource> (); //////// do Audio.
			hitParticles = GetComponentInChildren <ParticleSystem> ();
            capsuleCollider = GetComponent <CapsuleCollider> (); //// Da colisão da capsula.
            enemyMovement = this.GetComponent<EnemyMovement>(); ///// Do movimento do Enemy.
			currentHealth = startingHealth; /// Progresso da vida recebe valor da vida do inicio.
        }

      
      
           

        void Update ()
        {
            if (isSinking)
            {
                transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }
			
        public void TakeDano (int amount) //Sobre o dano que o inimgo vai levar.
        {
			if (IsDead)
				return;
			enemyAudio.Play (); //Quando levar dano toca o audio especifico pra tal.
			currentHealth -= amount; //E progresso da vida diminui.
		if (currentHealth <= 0f) //Se o progresso da vida baixar e for menor ou igual a 0 então chama Death();
			{

				Death ();
			}
        }

        void Death ()
        {
			IsDead = true;
			capsuleCollider.isTrigger = true;
		anim.SetTrigger ("Dead"); //Ativa a animação de Morte (TRIGGER)  após morte por colisão do tipo fantasma concernente a capsula do inimigo e raio de dano da arma do Player.

            enemyAudio.clip = deathClip; //Tocar o audio de morte do inimigo quando o mesmo morrer.
            enemyAudio.Play ();
		Destroy (gameObject, 4f);
        }

        public void StartSinking ()
        {
            GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
			GetComponent <Rigidbody> ().isKinematic = true;
		    isSinking = true;
            ScoreManager.Mortes += scoreValue;
			Destroy (gameObject,2f);
        }

	}