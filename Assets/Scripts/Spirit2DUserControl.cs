using UnityEngine;
using System.Collections;

public class Spirit2DUserControl : MonoBehaviour {

	[SerializeField] private float m_Speed = 10f;
	private Rigidbody2D m_Rigidbody2D;
	private int health = 0;
	public Texture healthicon;

	private void Awake()
    {
        // Setting up references.
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	public void Move(float movex, float movey) {
		m_Rigidbody2D.velocity = new Vector2(movex*m_Speed, movey*m_Speed);
	}

	private void OnGUI() {
		float imgWidth = Screen.width / 10;
		float imgHeight = imgWidth * 5 / 6;

		float adder = imgWidth * 3 / 4;
		float padding = 0;

		float imgY = Screen.height / 35;

		for (int i = 0; i < health; i++) {
			GUI.DrawTexture (new Rect(padding, imgY, imgWidth, imgHeight), healthicon);
			padding += (adder);
		}
	}
}