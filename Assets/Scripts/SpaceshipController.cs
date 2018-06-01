using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.XR.WSA;

public class SpaceshipController : MonoBehaviour
{

	public ParticleSystem LeftEngineParticle;
	public ParticleSystem RightEngineParticle;
	public Transform LeftEngineTransform;
	public Transform RightEngineTransform;
	public float EnginePower;
	
	private Rigidbody2D _spaceRigidbody;
	private float _spaceRotationZ;
	private Vector2 _engineForceVector;


	private void Start()
	{
		LeftEngineParticle.Stop();
		RightEngineParticle.Stop();
		_spaceRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		
		Debug.DrawRay(_spaceRigidbody.position, _engineForceVector * 10, Color.red);
		
		_spaceRotationZ = transform.rotation.eulerAngles.z;

		_engineForceVector.x = (Mathf.Sin(_spaceRotationZ * Mathf.PI / 180)) * -1;
		_engineForceVector.y = Mathf.Cos(_spaceRotationZ * Mathf.PI / 180);

		#region KeyEvents

		if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Space))
		{
			_spaceRigidbody.AddForceAtPosition(_engineForceVector * EnginePower * 2, _spaceRigidbody.position, ForceMode2D.Force);
		}
		
		if (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.F))
		{
			_spaceRigidbody.AddForceAtPosition(_engineForceVector * EnginePower, RightEngineTransform.position, ForceMode2D.Force);
		}
		
		if (Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.J))
		{
			_spaceRigidbody.AddForceAtPosition(_engineForceVector * EnginePower, LeftEngineTransform.position, ForceMode2D.Force);
		}

		#endregion		
		

	}

}
