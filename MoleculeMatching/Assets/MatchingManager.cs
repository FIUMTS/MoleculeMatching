using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour
{
    bool isMatchingA;
    bool isMatchingB;
    bool isMatchingC;
    bool isMatchingD;

    public delegate void ParticlesMatch();
    public static event ParticlesMatch OnParticlesMatch;

    // Update is called once per frame
    void Update()
    {
        if(isMatchingA && isMatchingB && isMatchingC && isMatchingD)
        {

        }
    }

}
