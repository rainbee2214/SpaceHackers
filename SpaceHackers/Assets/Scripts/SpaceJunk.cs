using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceJunk : Collectable
{
    SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;

    int currentSprite;

    public void Start()
    {
        LoadSprites();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = sprites[GetRandomSprite()];
        
    }

    void LoadSprites()
    {
        sprites = new List<Sprite>();
        for (int i = 0; i < 7; i++ ) //Doesn't like this path :(
            sprites.Add(Resources.Load("Sprites/Resource/junk" + i, typeof(Sprite)) as Sprite);
    }

    public int GetRandomSprite()
    {
        return Random.Range(0, sprites.Count);
    }

    public override void TurnOn()
    {
        //spriteRenderer.sprite = sprites[GetRandomSprite()];
    }

    public void TurnOn(int spriteIndex)
    {
        spriteRenderer.sprite = sprites[spriteIndex];
    }


    public override void Collect()
    {
        //base.Collect();
        Debug.Log("SpaceJunk!" + this.name);
        gameObject.SetActive(false);

        //Turn off and return yourself to the object pool of collectables.
    }
}
