using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collectable : MonoBehaviour 
{
    protected int value = 1;

    public virtual void Collect()
    {
        Debug.Log("Collectable :)" + this.name);
    }

    public virtual void TurnOn()
    {
        Debug.Log("Turning on " + this.name);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
    }
}
