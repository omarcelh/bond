using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

		private int health = 3;
		public Texture healthicon;
		public GameObject gameOverScreen;
		public GameObject clearScreen;
		private bool gameOver;
		private bool stageClear;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Grounded = false;
        }

		public void Update(){
			if (gameOver) {
				gameOverScreen.SetActive(true);
				gameObject.SetActive (false);
				//gameOver = false;
			} else if (stageClear) {
				clearScreen.SetActive(true);
				gameObject.SetActive (false);
				//clearScreen = false;
			}
		}

        private void FixedUpdate()
        {
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool jump)
        {
            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Anim.SetTrigger("Jump");
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
			Debug.Log (col.gameObject.tag);
			if (col.gameObject.tag == "Terrain") {
				m_Grounded = true;
			} else if (col.gameObject.tag == "Trap") {
				health--;
				gameOver = (health == 0);
				m_Grounded = true;
			} else if (col.gameObject.tag == "Collectible") {
				health++;
				stageClear = (col.gameObject.name == "orb");
				Destroy (col.gameObject);

			}
        }

		private void OnGUI() {
			float imgWidth = Screen.width / 10;
			float imgHeight = imgWidth * 5 / 6;

			float adder = imgWidth * 3 / 4;
			float padding = imgWidth;

			float imgY = Screen.height / 35;

			for (int i = 0; i < health; i++) {
				GUI.DrawTexture (new Rect(Screen.width - padding, imgY, imgWidth, imgHeight), healthicon);
				padding += adder;
			}
		}
    }
}
