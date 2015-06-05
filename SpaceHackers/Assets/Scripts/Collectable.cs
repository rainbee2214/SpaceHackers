using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collectable : MonoBehaviour 
{
    public virtual void Collect()
    {
        Debug.Log("Collectable :)" + this.name);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
    }
}
