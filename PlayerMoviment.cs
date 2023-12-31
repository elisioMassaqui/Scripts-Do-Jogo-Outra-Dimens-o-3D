﻿using UnityEngine;


public class PlayerMoviment : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody PlayerRigidbody;
	int floormask;
	float camRayLength = 100f;

	void Awake()
	{
		floormask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		PlayerRigidbody = GetComponent<Rigidbody> ();
	}
	void FixedUpdate()
	{

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);

	}

	void Move (float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		PlayerRigidbody.MovePosition (transform.position + movement);

	}


	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floormask))
		{
			Vector3 playertToMouse = floorHit.point - transform.position;
			playertToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playertToMouse);
			PlayerRigidbody.MoveRotation (newRotation);

		}

	}
	void Animating (float h,float v)
	{

		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
		
}
