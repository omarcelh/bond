using UnityEngine;
using System.Collections;

public class BackgroundFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.SetParent(Camera.main.gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
