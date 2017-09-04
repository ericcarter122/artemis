using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {

    private new AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(null, true, 100, 44100);
        audio.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) {}
        audio.Play();
        audio.mute = true;
    }

    void Update() {
        if (Input.GetKey(KeyCode.K)) {
            audio.mute = false;
        } else {
            audio.mute = true;
        }
    }
}
