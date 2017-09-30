using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Video;


public class Scripter : MonoBehaviour {

	VideoPlayer player;
    AudioSource source;
    

	public VideoClip Video1;
	public VideoClip Video2;
    int index = 0;


	// Use this for initialization
	void Start () {
		player = GetComponent<VideoPlayer> ();
        source = GetComponent<AudioSource> ();
        player.SetTargetAudioSource(0, source);

        player.clip = Video1;

//		StartCoroutine(lateStart)
	}
    

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (index == 0) {
				player.clip = Video1;
				player.Play ();
			}
			if (index == 1) {
				player.clip = Video2;
				player.Play ();
			}

			index++;
		}

    }

}
