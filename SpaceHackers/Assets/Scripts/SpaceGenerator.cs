using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceGenerator : MonoBehaviour
{
    const int lowerRange = 25;
    const int upperRange = 240;
    const int delta = 25;

    public Sprite stars;
    public List<SpriteRenderer> starTiles;

    public Color targetColor;
    public float speed = 0.2f;
    public bool changeColor = false;

    void Start()
    {
        stars = Resources.Load("Sprites/Backgrounds/BlackStarsBig", typeof(Sprite)) as Sprite;
        starTiles = new List<SpriteRenderer>();
        AddStarTile(Vector2.zero);
    
    }

    public void AddStarTile(Vector2 location)
    {
        GameObject tile = new GameObject("Sector001");
        tile.transform.SetParent(transform);
        tile.AddComponent<SpriteRenderer>();
        tile.GetComponent<SpriteRenderer>().sprite = stars;
        starTiles.Add(tile.GetComponent<SpriteRenderer>());

    }

    void Update()
    {
        if (changeColor)
        {
            changeColor = false;
            ChangeToRandomColor();
        }
        for (int i = 0; i < starTiles.Count; i++)
        {
            ColorizeStars(starTiles[i]);
        }
    }

    public void ChangeToRandomColor()
    {
        int r = lowerRange, b = lowerRange, g = lowerRange;
        
        switch (Random.Range(0,3000) % 3)
        {
            case 0: SetColors(ref r, ref b, ref g); break;
            case 1: SetColors(ref g, ref r, ref b); break;
            case 2: SetColors(ref b, ref r, ref g); break;
        }
        targetColor = new Color(r/255f, g/255f, b/255f, 1);
    }

    void SetColors(ref int c1, ref int c2, ref int c3)
    {
        c1 = lowerRange;
        c2 = Random.Range(lowerRange+delta, upperRange);
        c3 = Random.Range(lowerRange, upperRange);
        Debug.Log(c1);
        Debug.Log(c2);
        Debug.Log(c3);
    }

    void ColorizeStars(SpriteRenderer star)
    {
        star.color = Color.Lerp(star.color, targetColor, Time.deltaTime * speed);
    }
}
