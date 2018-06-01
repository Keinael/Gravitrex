using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Spaceship;
	public float ZRotation;
	public float MoveBuffer;
	public float SizeBuffer;
	public float Temp;

	private Rigidbody2D SpaceshipRigidbody;
	private Camera _cameraComponent;
	private Transform SpaceshipTransform;
	private Vector3 _newCameraPosition;

	private float PreviousCamSize;
	
	void Start ()
	{
		SpaceshipTransform = Spaceship.GetComponent<Transform>();
		SpaceshipRigidbody = Spaceship.GetComponent<Rigidbody2D>();
		ZRotation = transform.eulerAngles.z;
		_cameraComponent = gameObject.GetComponent<Camera>();

		StartCoroutine(GetPreviousCamSize());
	}

	private IEnumerator GetPreviousCamSize()
	{
		while (true)
		{
			PreviousCamSize = SpaceshipRigidbody.velocity.magnitude;
			yield return new WaitForSeconds(Temp);
		}
	}

	void FixedUpdate ()
	{
//		_cameraComponent.orthographicSize = Mathf.Lerp(PreviousCamSize + 6, 10, SizeBuffer);
		transform.position = Vector2.Lerp(SpaceshipTransform.position, transform.position, MoveBuffer);
		ZRotation = 0;
	}
}
