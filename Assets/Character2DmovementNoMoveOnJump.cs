using UnityEngine;
using System.Collections;

public class Character2DmovementNoMoveOnJump : MonoBehaviour 
{
	public float speed = 20.0f;
	public float defaultSpeed = 20.0f;
	public float maxSpeed = 4.0f;
	public bool canJump = true;
	public float jumpPower = 225.0f;

	void Update() 
	{
			if (Input.GetKey (KeyCode.RightArrow))
			{
			rigidbody2D.AddForce(transform.right * 20);
			}

			if (Input.GetKey (KeyCode.LeftArrow))
			{
			rigidbody2D.AddForce(-transform.right * 20);
			}

		// Jump
		if (Input.GetKeyDown (KeyCode.Space) /*&& canJump == true*/)
		{
			rigidbody2D.AddForce(transform.up * jumpPower);	
			canJump = false;
			Debug.Log ("jump");
		}

		// Stationary jump
		if (rigidbody2D.velocity.x < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.RightArrow))
		{
			rigidbody2D.AddForce(transform.right * speed);	
		}

		if (rigidbody2D.velocity.x < 2.0f 
		    && Input.GetKey (KeyCode.Space) 
		    && Input.GetKey (KeyCode.LeftArrow))
		{
			rigidbody2D.AddForce(-transform.right * speed);	
		}


		//Sprint
		if (Input.GetKey (KeyCode.LeftShift))
		{
			speed = maxSpeed;
		}

		if (!Input.GetKey (KeyCode.LeftShift))
		{
			speed = defaultSpeed;
		}
	}

	public void FixedUpdate() 
	{		
		rigidbody2D.velocity = new Vector2 
			(
			Mathf.Clamp(rigidbody2D.velocity.x, -speed, speed),
			Mathf.Clamp(rigidbody2D.velocity.y, -500, 5)
			);
	}
}