﻿using UnityEngine;
using System.Collections;

// Logic for the main rolling ball object
// Matthew Cormack @johnjoemcbob
// 11/03/16 19:33

public class BallScript : MonoBehaviour
{
	public float GravityMultiplier = 9.8f;
	public float AndroidMultiplier = 10;

	private Vector3 Gravity = Vector3.zero;

	void Start()
	{
		if ( Application.platform != RuntimePlatform.Android )
		{
			AndroidMultiplier = 1;
		}
	}

	void Update()
	{
		Rigidbody body = GetComponent<Rigidbody>();
		if ( !body ) return;

		//body.velocity = Vector3.zero;
		//body.angularVelocity = Vector3.zero;
		body.AddForce( Gravity * GravityMultiplier * AndroidMultiplier * Time.deltaTime );

		// Update the rolling audio depending on the speed of movement
		float speed = Mathf.Clamp( body.angularVelocity.magnitude / 10, 0, 1 );
		float vol = GetComponent<AudioSource>().volume;
		GetComponent<AudioSource>().volume = vol + ( ( ( speed / 2 ) - vol ) * Time.deltaTime * 10 );
		GetComponent<AudioSource>().pitch = 1.05f + ( speed / 4 );
    }

	public void SetGravity( Vector3 gravity )
	{
		Gravity = gravity;
	}
	public void AddGravity( Vector3 gravity )
	{
		Gravity += gravity;
	}
}
