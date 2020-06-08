using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform ball;
	public float smoothSpeed = 0.125f;
	public GameObject speedLinesEffect;

	void FixedUpdate()
	{
		Vector3 desiredPosition = new Vector3(this.transform.position.x, this.transform.position.y, ball.position.z);
		transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		speedLinesEffect.transform.position = new Vector3(speedLinesEffect.transform.position.x, speedLinesEffect.transform.position.y, this.transform.position.z);
	}
}
