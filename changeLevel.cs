using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLevel : MonoBehaviour {



	void Update()
	{
		//Pra carregar uma determinada cena. pressionando uma tecla
		if (Input.GetKeyDown (KeyCode.T)) {
			Application.LoadLevel ("Main");
		} 
	}

}
