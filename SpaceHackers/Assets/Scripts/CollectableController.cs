using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableController : MonoBehaviour
{
    public static int NUM_JUNK_SPRITES = 5;
    public static int NUM_ORGNICS_SPRITES = 5;

    public enum SpriteType
    {
        SpaceJunk,
        SpaceOrganics
    }

    public static void GetSprites(ref List<Sprite> sprites, SpriteType spriteType)
    {
        string resource = "junk";
        int max = 0;
        switch(spriteType)
        {
            case SpriteType.SpaceJunk: resource = "junk"; max = NUM_JUNK_SPRITES; break;
            case SpriteType.SpaceOrganics: resource = "organics"; max = NUM_ORGNICS_SPRITES; break;
        }
        sprites = new List<Sprite>();
        for (int i = 0; i < max; i++) //Doesn't like this path :( Going to change the names later when I rename the assets
            sprites.Add(Resources.Load("Sprites/Resource/"+resource + i, typeof(Sprite)) as Sprite);
    }

}
