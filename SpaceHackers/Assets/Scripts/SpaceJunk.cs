using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceJunk : Collectable
{
    SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;

    public void Start()
    {
        SetSprite();
        
    }

    void SetSprite()
    {
        sprites = new List<Sprite>();
        for (int i = 0; i < 7; i++ ) //Doesn't like this path :(
            sprites.Add(Resources.Load("Sprites/Resource/junk" + i, typeof(Sprite)) as Sprite);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        gameObject.SetActive(false);
    }
    
    public override void Collect()
    {
        //base.Collect();
        Debug.Log("SpaceJunk!" + this.name);

        //Turn off and return yourself to the object pool of collectables.
    }
}
