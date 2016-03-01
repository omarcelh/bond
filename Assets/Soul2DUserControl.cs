using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (StaticFlyingCharacter2D))]
	public class Soul2DUserControl : MonoBehaviour {
		private StaticFlyingCharacter2D m_Soul;

		private void Awake()
        {
            m_Soul = GetComponent<StaticFlyingCharacter2D>();
        }


        private void Update()
        {
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Soul.Move(h, v);
        }
	}
}