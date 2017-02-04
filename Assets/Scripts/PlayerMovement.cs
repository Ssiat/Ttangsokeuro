using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public int speed = 5;

	private Rigidbody2D _rigidbody2D;

	void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");

		Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);

		_rigidbody2D.AddForce(movement * speed);
	}

	/*
	void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.position = new Vector3(transform.position.x + moveHorizontal, transform.position.y + moveVertical, 0f);
	}
	*/
}
