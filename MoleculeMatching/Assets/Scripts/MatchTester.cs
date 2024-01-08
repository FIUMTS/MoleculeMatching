using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Molecule Matcher is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.
 */
public class MatchTester : MonoBehaviour
{
    // Start is called before the first frame update
   
    public static event EventHandler<OnParticleMatchEventArgs> OnParticleMatch;
    public static event EventHandler<OnParticleUnmatchEventArgs> OnParticleUnmatch;

    //the two classes below exist to allow the events to pass in arguments. In this case, passing the name of the particle.
    public class OnParticleUnmatchEventArgs : EventArgs {  public string particle; }
    public class OnParticleMatchEventArgs : EventArgs {  public string particle; }

    private void OnTriggerEnter(Collider other)
    {
        //The code block below fires an event for subscribers if the name of the object colliding matches the name of the object that this script is attached to.
        if (this.name == other.name)
        { 
            OnParticleMatch?.Invoke(this, new OnParticleMatchEventArgs { particle = this.name });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.name == other.name)
        {
            OnParticleUnmatch?.Invoke(this, new OnParticleUnmatchEventArgs { particle = this.name });
        }
    }
}
