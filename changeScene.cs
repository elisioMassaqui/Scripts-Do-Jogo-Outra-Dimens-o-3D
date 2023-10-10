using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {


	public void ChangeScenes (string nomeCena)
	{
		Application.LoadLevel (nomeCena);
	}

//	public void SairDoJogo()
//	{
//		Application.LoadLevel
//	}


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) { 

			Application.LoadLevel ("First Map");
		}
	}
		

}
