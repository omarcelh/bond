using UnityEngine;
using System.Collections;

public class LittleGirlController : MonoBehaviour {
	// movement config
	public float gravity = -15f;
	public float maxRunSpeed = 8f;
	public float accelerate = 4f;
	// public float groundDamping = 20f; // how fast do we change direction? higher means faster
	// public float inAirDamping = 5f;
	// public float jumpWaitTime = 2.0;

	[HideInInspector]
	public float rawMovementDirection = 1;
	//[HideInInspector]
	public float normalizedHorizontalSpeed = 0;

	public RaycastHit2D lastControllerColliderHit;

	[HideInInspector]
	public Vector3 velocity;

	// Animation States
	/*private int walkState = Animator.StringToHash("Walking");
	private int idleState = Animator.StringToHash("Standing");*/

	private Prime31.CharacterController2D _controller;
	private Animator _animator;

	private int jumpCount = 0; // to disallow triple jump

	void Awake () {
		_controller = GetComponent<Prime31.CharacterController2D> ();
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// grab our current velocity to use as a base for all calculations
		var velocity = _controller.velocity;

		if (_controller.isGrounded) {
			velocity.y = 0;
			jumpCount = 0;
		}

		//horizontal input
		if (Input.GetKey (KeyCode.D)) {
			normalizedHorizontalSpeed = 1;
			velocity.x = normalizedHorizontalSpeed * maxRunSpeed;
			if (transform.localScale.x < 0f)
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			if (_controller.isGrounded)
				_animator.SetBool("IsWalking", true);
		} else if( Input.GetKey( KeyCode.A ) )	{
				normalizedHorizontalSpeed = -1;
				velocity.x = normalizedHorizontalSpeed * maxRunSpeed;
				if( transform.localScale.x > 0f )
					transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );

				if(_controller.isGrounded)
					_animator.SetBool("IsWalking", true);
		} else {
			normalizedHorizontalSpeed = 0;
			velocity.x = normalizedHorizontalSpeed;

			if( _controller.isGrounded )
				_animator.SetBool("IsWalking", false);
		}

		if( Input.GetKeyDown( KeyCode.W ) )
		{	
			if (jumpCount < 2) {
				velocity.y = 20f;
				jumpCount++;
				_animator.SetBool("IsJumping", true);
			}
				
			// _animator.Play( Animator.StringToHash( "Jump" ) );
		}


		velocity.y += gravity;

		_controller.move (velocity * Time.deltaTime );


	}
}
