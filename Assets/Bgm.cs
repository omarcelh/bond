using UnityEngine;
using System.Collections;

public class Bgm : MonoBehaviour {
	public AudioClip bgm;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GameObject.Find ("Audio Source").GetComponent<AudioSource> ();
		source.clip = bgm;
		source.Play ();
	}

}
