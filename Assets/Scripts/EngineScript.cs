using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour
{
	
	public KeyCode EngineActivationButton;
	public float EnginePower;
	
	private Rigidbody2D _spaceshipRigidbody;
	private Transform _spaceshipTransform;
	private Vector2 _engineForceVector;
	private float _spaceRotation;
	
	void Start ()
	{
		_spaceshipRigidbody = gameObject.GetComponentInParent<Rigidbody2D>();
		_spaceshipTransform = gameObject.GetComponentInParent<Transform>();
	}
	
	void FixedUpdate ()
	{

		_spaceRotation = _spaceshipTransform.rotation.eulerAngles.z;

		_engineForceVector.x = -(Mathf.Sin(_spaceRotation * Mathf.PI / 180));
		_engineForceVector.y = Mathf.Cos(_spaceRotation * Mathf.PI / 180);
		
		while (Input.GetKey(EngineActivationButton))
		{
			_spaceshipRigidbody.AddForceAtPosition(_engineForceVector * EnginePower, gameObject.transform.position, ForceMode2D.Force);
		}
	}
	
	
}
