using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

    public Animator animator;
    public Animator jumpSpin;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        jumpSpin.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetTrigger("IsJumping");
            jumpSpin.SetTrigger("IsJumping");
		}
                
        if(Input.GetButtonDown("Reset"))
        {
            LevelLoader.instance.Reset();
        }

        if(Input.GetButtonDown("Next"))
        {
            LevelLoader.instance.LoadNextLevel();
        }

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

    public void OnLanding()
    {
        //animator.SetTrigger("IsJumping", false);
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}