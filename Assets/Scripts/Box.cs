using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Trap") {
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
