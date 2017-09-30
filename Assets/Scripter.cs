using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Video;


public class Scripter : MonoBehaviour {

	VideoPlayer player;
    AudioSource source;

    public VideoClip initialLoop;
    public VideoClip testLoop;
    public VideoClip finalVideo;

    public GameObject initialText;
    public GameObject testCompleteText;
    public GameObject winText;

    public float showTestCompleteAfter = 60;
    public int showFinalVideoAfterLoopCount = 3;

    int testLoopCount = 0;

	//public VideoClip Video1;
	//public VideoClip Video2;
    //int index = 0;


	// Use this for initialization
	void Start () {
		player = GetComponent<VideoPlayer> ();
        source = GetComponent<AudioSource> ();
        player.SetTargetAudioSource(0, source);
        
        player.isLooping = true;
        player.loopPointReached += Player_loopPointReached;
        StartInitialLoop();
        //		StartCoroutine(lateStart)
    }

    private void Player_loopPointReached(VideoPlayer source)
    {
        Debug.Log("Player_loopPointReached " + testLoopCount);

        if (player.clip == finalVideo)
        {
            StartInitialLoop();
            return;
        }

        testLoopCount++;
        if (testLoopCount >= showFinalVideoAfterLoopCount)
        {
            player.clip = finalVideo;
            player.Play();
            initialText.SetActive(false);
            testCompleteText.SetActive(false);
            winText.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (player.clip == initialLoop)
            {
                StartTestLoop();
            } else if (player.clip == testLoop)
            {
                StartInitialLoop();
            }

		}

    }

    void StartInitialLoop()
    {
        player.clip = initialLoop;
        player.Play();
        initialText.SetActive(true);
        testCompleteText.SetActive(false);
        winText.SetActive(false);
    }

    void StartTestLoop()
    {
        player.clip = testLoop;
        player.Play();
        testLoopCount = 0;
        initialText.SetActive(false);
        testCompleteText.SetActive(true);
        winText.SetActive(false);
    }
}
