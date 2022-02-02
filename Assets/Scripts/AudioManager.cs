using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource shoot;
    public AudioSource gameOver;
    public AudioSource click;

    public void Shooting()
    {
        shoot.Play();
    }

    public void GameOver()
    {
        gameOver.Play();
    }

    public void Click()
    {
        click.Play();
    }
    
}
