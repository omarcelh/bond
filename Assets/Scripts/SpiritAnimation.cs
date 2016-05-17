using UnityEngine;
using System.Collections;

public class SpiritAnimation : MonoBehaviour {

	public float acceleration = 0.0008f;
	private float speed = 0;
	private int direction = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (speed >= 0.012f)
			direction = -1;
		if (speed <= -0.012f)
			direction = 1;
		speed += direction * acceleration;
		transform.position = new Vector2(transform.position.x, transform.position.y + speed);

	}
}
