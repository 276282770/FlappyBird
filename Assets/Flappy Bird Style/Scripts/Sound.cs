using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Sound : MonoBehaviour {

    public AudioClip clipClick;
    public AudioClip[] clipsP1;
    public AudioClip[] clipsP2;
    public AudioClip clipGameOver;
    public AudioSource audioSource;
    public AudioSource audioBgSource;

    public static Sound Instance;
    private void Start()
    {
        Instance = this;
    }
    public void PlayClick()
    {
        audioSource.clip = clipClick;
        audioSource.Play();
    }
    public void PlayP1()
    {
        int idx = new System.Random().Next(0, clipsP1.Length);
        audioSource.clip = clipsP1[idx];
        audioSource.Play();
    }
    public void PlayP2()
    {
        int idx = new System.Random().Next(0, clipsP2.Length);
        audioSource.clip = clipsP2[idx];
        audioSource.Play();
    }
    public void Play()
    {
        audioBgSource.Play();
    }
    public void Stop()
    {
        audioBgSource.Stop();
    }
    public void PlayGameOver()
    {
        audioSource.clip = clipGameOver;
        audioSource.Play();
    }
}
