using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camraLenta : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.C)) {

			Time.timeScale = 0.4f;
		}

		else if (Input.GetKey (KeyCode.V)) {

			Time.timeScale = 1f;
		}
	}
}
