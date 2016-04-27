using UnityEngine;
using System.Collections;

public class Spirit2DUserControl : MonoBehaviour {

	[SerializeField] private float m_Speed = 10f;
	private Rigidbody2D m_Rigidbody2D;
	private void Awake()
    {
        // Setting up references.
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	public void Move(float movex, float movey) {
		m_Rigidbody2D.velocity = new Vector2(movex*m_Speed, movey*m_Speed);
	}
}