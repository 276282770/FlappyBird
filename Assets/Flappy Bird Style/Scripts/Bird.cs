﻿using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

        if (!GameControl.instance.gameStart)
        {
            SetStop();
        }
	}

	void Update()
	{
		//Don't allow control if the bird has died.
		if (isDead == false&&GameControl.instance.gameStart) 
		{
			//Look for input to trigger a "flap".
			if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)) 
			{
                if (GameManager.Instance.playerIdx == 0)
                {
                    Sound.Instance.PlayP1();
                }
                else if (GameManager.Instance.playerIdx == 1)
                {
                    Sound.Instance.PlayP2();
                }
				//...tell the animator about it and then...
				anim.SetTrigger("Flap");
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//	new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}
    public void SetStart()
    {
        rb2d.isKinematic = false;
    }
    public void SetStop()
    {
        rb2d.isKinematic = true;
    }

	void OnCollisionEnter2D(Collision2D other)
	{
        if (other.transform.tag == "Obstacle")
            return;
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
	}
}
