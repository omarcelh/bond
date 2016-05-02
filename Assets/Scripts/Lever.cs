using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
	public GameObject kotak;

	private bool isAchieved = false;

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Vector2 target;
			if (kotak.transform.position.x > 25.3f)
				isAchieved = true;
			if (!isAchieved) {
				target = new Vector2 (kotak.transform.position.x + 2.5f, kotak.transform.position.y + 2.0f);
				kotak.transform.position = Vector2.Lerp (kotak.transform.position, target, Time.deltaTime);
			} 
		}
	}
}
