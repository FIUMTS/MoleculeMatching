using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnMatch : MonoBehaviour
{
    
    private void Start()
    {
        MatchingManager.OnMatch += PlayParticle;
    }

    private void PlayParticle(object sender, EventArgs e)
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play();
        MatchingManager.OnMatch -= PlayParticle;
    }
}
