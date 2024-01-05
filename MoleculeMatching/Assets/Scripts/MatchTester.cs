using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
