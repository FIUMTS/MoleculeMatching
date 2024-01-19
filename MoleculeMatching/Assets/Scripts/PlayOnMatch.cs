using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnMatch : MonoBehaviour
{
    private ParticleSystem pSystem;

    private void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        MatchingManager.OnMatch += PlayParticle;
        NotAMatchButton.OnNotAMatchButtonPressed += TurnParticleSysRed;
    }

    private void PlayParticle(object sender, EventArgs e)
    {
        
        pSystem.Play();
        MatchingManager.OnMatch -= PlayParticle;
    }

    private void TurnParticleSysRed(object sender, EventArgs e)
    {
        var main = pSystem.main;
        main.startColor = Color.red;
        NotAMatchButton.OnNotAMatchButtonPressed -= TurnParticleSysRed;
        pSystem.Play();
    }

    private void OnDestroy()
    {
        NotAMatchButton.OnNotAMatchButtonPressed -= TurnParticleSysRed;
        MatchingManager.OnMatch -= PlayParticle;
    }
}
