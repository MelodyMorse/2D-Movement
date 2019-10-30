using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

    public float jumpHeight = 4.0f;
	public float runSpeed = 1f;
    

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate ()
	{
        // Move our character
        //Debug.Log("fdt: " + Time.fixedDeltaTime);
        //not multiplying horizontal move by fixedDeltTime. I think this is okay but look into it
        controller.Move(horizontalMove, crouch, jump);

		jump = false;
	}
}
