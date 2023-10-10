using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hit : MonoBehaviour {

	//Código da Arma.

	//Dano ou colisão da arma aos objecs ou inimigos.
	[Header ("Arma")]
	public int damage = 10; //Tamanho do dano
	public float range = 100f; //Alcance
	public float fireRate = 60;
	public int maxAmmoPent = 17; //Máximo de muniçao que tem no Pente
	public int currentAmmoPent;	 //Progresso da munição que tem no Pente
	public int pistolAmmo = 90;
	public int moreAmmo = 120;
	public int reloadTime = 10;

	public float impactForce = 30f;

	private float nextTimeToFire = 0f;



	[Header ("Camera e Efeitos")]
	public Camera cam; //A camera onde é atribuida a origem do raio de colisão.
	public ParticleSystem fogo; //Efeito de fogo no cano da arma ao disparar.
	//public GameObject impactSmoke; //Efeito do impacto da bala.


	[Header ("Animações")]
	public Animator anim;
	private bool isReloading = false;
	bool disparar = false;


	[Header ("Audio")]
	public GameObject Fogo; //Qual é o som que arma faz quando dispara???
	public GameObject FireNoBullet; //Sem balas faz um barulhinho diferente.
	public AudioSource reload; // Sound de quando trocamos o carregador.


	[Header ("Upgrades")]


	[Header ("Canvas")]
	public Text ammoText;
	public Slider RechargeShow;
	public GameObject rechargeGO;



	void Start()
	{
		currentAmmoPent= maxAmmoPent; //Carregador recebe o máximo de balas que deve conter.
		RechargeShow.maxValue = reloadTime; //Valor máximo do tempo da recarga do slider.
	}
		
	void Update()
	{
		RechargeShow.value = reloadTime;
		ammoText.text = currentAmmoPent +"/"+ pistolAmmo;
		if (isReloading)
			return;
		
		if (Input.GetButtonDown ("Recharge") && currentAmmoPent != maxAmmoPent && pistolAmmo >0 && isReloading == false)  //Se o progresso da bala for igual ou menor que 0 então recarrega o pente.
		{ 
			rechargeGO.SetActive (true); //Ativar o slider quando estiver a carregar a arma.
			reload.Play();
//			Reload();Tenha cuidado Elísio o metódo coroutine não se chama desse jeito como a maioria mas sim desse jeito:
			StartCoroutine(Reload()); //Começar a coroutine com metódo lá dentro,nesse caso de tempo de recarga.
			return;
		}

		if(Input.GetButton ("Fire1")&& Time.time >= nextTimeToFire && currentAmmoPent > 0) // Se apertar botão Mouse,chama a funçao de disparar.
		{
			Shoot ();
			nextTimeToFire = Time.time + 1f / fireRate;
			anim.SetBool ("Shoot", true);
		}
		else
		{
			anim.SetBool ("Shoot", false);
		}
	}
	IEnumerator Reload() //Coroutine pra determinar e ativar o tempo da recarga.
	{
		isReloading = true;
		Debug.Log ("Recarregando...");
		anim.SetBool ("Reloading", true);

		//Se Balas fora do carregador for maior que o tamanho máximo do pente.
		if (pistolAmmo >= maxAmmoPent) { 
			currentAmmoPent = maxAmmoPent;//Então carregador vai receber o limite que pode possuir no Pente.
			pistolAmmo -= maxAmmoPent; //Balas fora do carregador vai ser menor que limite de balas,ou seja, maxAmmoPent
		} else {
			currentAmmoPent = pistolAmmo; //Carregador recebe a bala que está fora do carregador
			pistolAmmo = 0; //E a bala fora do carregador é igual a 0.
		}

		yield return new WaitForSeconds (reloadTime); //Tempo de recarga.

		anim.SetBool ("Reloading", false);
		currentAmmoPent = maxAmmoPent; //Progresso da munição recebe maxima munição
		isReloading = false;
		rechargeGO.SetActive (false);
	}
		
	void Shoot()
	{
		Instantiate (Fogo, transform.position, transform.rotation, transform); //Pra instanciar o audio de disparo da arma.
//		anim.SetBool ("Shoot", true);

		currentAmmoPent --;//Sempre que apertar no botão de dispar vai descontar na bala --;

		fogo.Play (); //Instanciar efeitos de fogo de tiro no cano da arma.

		RaycastHit hit; //Sobre o raio de colisão ou dano do Raycast na camera.
		if (Physics.Raycast (cam.transform.position, cam.transform.forward , out hit, range)) //Condição pra instanciar o raio de dano ou colisão que sai da arma.
		{
			Debug.Log ("Mirando Algo"); //Printar aonde estamos a mirar.
			//Destruir Objeto depois de alguns tiros.

			destruirParede wb = hit.collider.GetComponent<destruirParede>(); //Pegar o componente de destruir Parede.
			if (wb != null)
				wb.Damage (damage); //Deixar cair por pedaços.

			todaparedeDetected bd = hit.collider.GetComponent<todaparedeDetected>();
			if (bd != null)
				bd.getdown();
			print ("GetDown");

			EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth> (); //Pegar o componente o Script de vida do inimigo.
		
			DestruirObj ob = hit.transform.GetComponent<DestruirObj> (); //Pegar o componente o Script de vida dos objetos(caixas coloridas)

			if (enemyHealth != null) { //Condição pra levar dano,acessando o script da vida do inimigo nesse.
				enemyHealth.TakeDano (damage); //Danifica.
			}

			else
			{
				
				if (ob != null)
					ob.takeDamage (damage); //Destroi o Objecto com tiros.
			}
		}

		if (hit.rigidbody != null) 
		{

			hit.rigidbody.AddForce (hit.normal * impactForce); //Força da munição ao colidir com outros obj.
		}

		//GameObject impactGo = Instantiate (impactSmoke, hit.point, Quaternion.LookRotation (hit.normal));
		//Destroy (impactGo, 0.8f);
	}
}
