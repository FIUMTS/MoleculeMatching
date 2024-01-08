using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */

public class MatchingManager : MonoBehaviour
{
    bool moleculeA;
    bool moleculeB;
    bool moleculeC;
    bool moleculeD;

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
