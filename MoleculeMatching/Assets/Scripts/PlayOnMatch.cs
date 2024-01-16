using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnMatch : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        MatchingManager.OnMatch += PlayParticle;
        NotAMatchButton.OnNotAMatchButtonPressed += TurnParticleSysRed;
    }

    private void PlayParticle(object sender, EventArgs e)
    {
        
        particleSystem.Play();
        MatchingManager.OnMatch -= PlayParticle;
    }

    private void TurnParticleSysRed(object sender, EventArgs e)
    {
        var main = particleSystem.main;
        main.startColor = Color.red;
        NotAMatchButton.OnNotAMatchButtonPressed -= TurnParticleSysRed;
    }
}
