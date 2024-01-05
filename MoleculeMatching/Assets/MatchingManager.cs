using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour
{

    [SerializeField]

    bool moleculeA;
    bool moleculeB;
    bool moleculeC;
    bool moleculeD;
    bool isAMatch;

    public static EventHandler OnMatch;

    private void Start()
    {
        MatchTester.OnParticleMatch += Match_OnParticleMatch;
        MatchTester.OnParticleUnmatch += Unmatch_OnParticleUnmatch;
    }

    private void Match_OnParticleMatch(object sender, MatchTester.OnParticleMatchEventArgs e)
    {
        Debug.Log(e.particle + " found a match.");
        switch (e.particle)
        {
            case "A": moleculeA = true; break;
            case "B": moleculeB = true; break;
            case "C": moleculeC = true; break;
            case "D": moleculeD = true; break;
        }

        if(moleculeA && moleculeB && moleculeC && moleculeD)
        {
            Debug.Log("IT'S A MATCH");
            MatchTester.OnParticleMatch -= Match_OnParticleMatch;
            MatchTester.OnParticleUnmatch -= Unmatch_OnParticleUnmatch;
            OnMatch?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Unmatch_OnParticleUnmatch(object sender, MatchTester.OnParticleUnmatchEventArgs e)
    {
        Debug.Log(e.particle + " no longer matching.");
        switch (e.particle)
        {
            case "A": moleculeA = false; break;
            case "B": moleculeB = false; break;
            case "C": moleculeC = false; break;
            case "D": moleculeD = false; break;
        }
    }
}
