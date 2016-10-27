using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public int speed = 5;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.position = new Vector3(transform.position.x + moveHorizontal, transform.position.y + moveVertical, 0f);
	}
}
