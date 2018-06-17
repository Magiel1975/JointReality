using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class JointManager : Singleton<JointManager> {

    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartSound()
    {
        if (audio != null && !audio.isPlaying)
        {
            audio.Play();
        }
    }
    public void StopSound()
    {
        if (audio != null && audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
