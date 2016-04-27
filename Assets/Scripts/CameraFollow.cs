using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform[] player;
	public float time = 0.3f;

	private Vector3 velocity = Vector3.zero;
	private int currentPlayer;
		
	void Start(){
		currentPlayer = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			player[currentPlayer].gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			switch (currentPlayer) {
			case 0:
				player[currentPlayer].gameObject.GetComponent<Animator>().SetFloat("Speed", 0);
				player[currentPlayer].gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
				currentPlayer = 1;
				player[currentPlayer].gameObject.GetComponent<SpiritController>().enabled = true;
				break;
			case 1:
				player[currentPlayer].gameObject.GetComponent<SpiritController>().enabled = false;
				currentPlayer = 0;
				player[currentPlayer].gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;
				break;
			}
			Debug.Log(player[currentPlayer]);
		}
		updatePosition ();
	}

	void updatePosition(){
		Vector3 target = new Vector3 (player [currentPlayer].position.x, transform.position.y, transform.position.z);
		if (target.x < 1.3f)
			target.x = 1.3f;
		else if (target.x > 50.5f)
			target.x = 50.5f;
		transform.position = Vector3.SmoothDamp (transform.position, target, ref velocity, time);
	}
}

