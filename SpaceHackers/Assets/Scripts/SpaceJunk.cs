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
        TurnOn();
    }

    void LoadSprites()
    {
        CollectableController.GetSprites(ref sprites, CollectableController.SpriteType.SpaceJunk);
    }

    public int GetRandomSprite()
    {
        return Random.Range(0, sprites.Count);
    }

    public override void TurnOn()
    {
        Debug.Log("Turning on");
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
