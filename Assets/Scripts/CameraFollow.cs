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
			switch (currentPlayer) {
			case 0:
				currentPlayer = 1;
				break;
			case 1:
				currentPlayer = 0;
				break;
			}
		}
		updatePosition ();
	}

	void updatePosition(){
		Vector3 target = new Vector3 (player [currentPlayer].position.x, transform.position.y, transform.position.z);
		if (player[currentPlayer].position.x > 0.6f && player[currentPlayer].position.x < 50.5f) {
			transform.position = Vector3.SmoothDamp (transform.position, target, ref velocity, time);
		} 
	}
}

