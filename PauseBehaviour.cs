using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour {


	[Header("Canvas")]
	public GameObject GameUI; // Pra controlar o Canvas principal.
	public GameObject PauseUI; //Pra controlar o Canvas secundário concernente ao menu de Pausa.

	[Header("Objectos")]
	public GameObject soundTrack;


	void Start()
	{
		PauseUI = transform.GetChild (0).gameObject;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			PauseGame ();
		}
	}

	public void PauseGame()
	{
		Cursor.lockState = CursorLockMode.None;
		GameUI.SetActive (false);
		PauseUI.SetActive (true);
		soundTrack.SetActive (false);

		Time.timeScale = 0f;
	}

	public void ResumeGame()
	{
		Cursor.lockState = CursorLockMode.Locked;
		GameUI.SetActive (true);
		PauseUI.SetActive (false);
		Time.timeScale = 1;
		soundTrack.SetActive (true);
	}

	public void MenuPrincipal()
	{
		Cursor.lockState = CursorLockMode.None;
		Application.LoadLevel ("MainMenu");
		GameUI.SetActive (true);
		PauseUI.SetActive (false);
		Time.timeScale = 1;
	}

}
	
