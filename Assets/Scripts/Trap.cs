using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {
	public float interval = 2.0f;
	public GameObject trap;
	private float currentTime = 0f;
	private bool isUp = false;

	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime > interval) {
			isUp = !isUp;
			currentTime = 0;
		} 

		float adder;
		if (isUp) {
			adder = Time.deltaTime;
		} else {
			adder = -Time.deltaTime;
		}


		trap.transform.position = new Vector3 (
			trap.transform.position.x,
			trap.transform.position.y + adder,
			trap.transform.position.z
		);
	}
}
