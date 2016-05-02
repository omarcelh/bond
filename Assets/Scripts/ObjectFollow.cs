using UnityEngine;
using System.Collections;

public class ObjectFollow : MonoBehaviour {
	private GameObject target;

	void OnCollisionStay2D(Collision2D hit){
		target = hit.gameObject;
		target.gameObject.transform.parent = transform;
	}
}
