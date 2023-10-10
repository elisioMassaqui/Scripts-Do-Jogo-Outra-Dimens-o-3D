using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

    public class PlayerHealth : MonoBehaviour
    {
        public int startingHealth = 100; //Vida total e do inicio.
        public int currentHealth; //Progresso da vida.
        public Slider healthSlider; //Barra de Saude.
        public Image damageImage; //Imagem vermelha de dando que pisca no canvas quando Player é atacado pelo Enemy
        public AudioClip deathClip;
        public float flashSpeed = 5f; //velocity do Flash da imagem de dano no canvas.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //Cor da imagem de dano.
        public bool godMode = false;

        Animator anim;
        AudioSource playerAudio;
        PlayerMoviment playerMoviment; //Acessar aos componentes do Script do movimemto do Jogador.
		PalyerController palyerController; //Acessar aos componentes do Script Do Controle do Jogador.
		Gun gun; //Acessar aos componentes do Script Da arma do Jaogador.
		

		hit Hit; //Acessar aos componentes do Script Do Raio e dano da arma do jogador.
      
        bool isDead;
        bool damaged;

        void Awake()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		playerMoviment = GetComponent<PlayerMoviment>();         //////////////Pegar os componentes do GameObject da Hierarquia ou de Outros Scripts pra depois serem usados nas funções e váriaveis.
		palyerController = GetComponent<PalyerController>();
		gun = GetComponent<Gun>();
		Hit = GetComponentInChildren<hit> ();
		currentHealth = startingHealth;

	}
  

        void Update()
        {
			
            // If the player has just been damaged...
            if (damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

		if (currentHealth <= 0) { 
		Application.LoadLevel ("GameOver");
//			palyerController.enabled = false;
//			Hit.enabled = false;
//			gun.enabled = false;
//

		}

            // Reset the damaged flag.
            damaged = false;
        }


        public void TakeDamage(int amount)
        {
            if (godMode)
                return;

            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            healthSlider.value = currentHealth;

            // Play the hurt sound effect.
            playerAudio.Play();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
			Death();
			print("No Life");
            }
        }

        void Death()
        {
//            // Set the death flag so this function won't be called again.
//            isDead = true;
//
//            // Turn off any remaining shooting effects.
////           playerShooting.DisableEffects();
//
//            // Tell the animator that the player is dead.
//            anim.SetTrigger ("IsDead");
//			
//            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
//            playerAudio.clip = deathClip;
//            playerAudio.Play();
//
//            // Turn off the movement and shooting scripts.
//			playerMoviment.enabled = false;
//            Hit.enabled = false;

        }

   
    }