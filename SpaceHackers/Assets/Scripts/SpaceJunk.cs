using UnityEngine;
using System.Collections;

public class SpaceJunk : Collectable
{
    public override void Collect()
    {
        //base.Collect();
        Debug.Log("SpaceJunk!" + this.name);

        //Turn off and return yourself to the object pool of collectables.
    }
}
