using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class SpiritController : MonoBehaviour {
	private Spirit2DUserControl m_Soul;

	private void Awake()
    {
        m_Soul = GetComponent<Spirit2DUserControl>();
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
