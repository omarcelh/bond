using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public int life = 1;
	public Canvas GameOverScreen;
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Trap") {
			life--;
			if (life <= 0 && !gameOver) {
				Instantiate (GameOverScreen);
				gameOver = true;
			}
		}
	}
}
