using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct SolarSystem
{
    public GameObject star;
    public Vector2 location;
    public int sectorIndex;
}

public class SpaceGenerator : MonoBehaviour
{
    const int lowerRange = 25;
    const int upperRange = 240;
    const int delta = 25;
    const int xSize = 40;
    const int ySize = 30;

    public Sprite stars;
    int poolSize = 9;
    int TOP = 0;
    public List<SpriteRenderer> starTiles;
    public List<Vector2> sectorLocations;
    public List<SolarSystem> solarSystems;

    List<GameObject> baseStars;

    public Color targetColor;
    public float speed = 0.2f;
    public bool changeColor = false;
    public bool changeSector = false;
    public bool incrementSector = false;

    int lastSector;
    public int currentSector;
    public GameObject player;

    float sectorCheckDelay = 0.3f;
    float nextSectorCheckTime;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stars = Resources.Load("Sprites/Backgrounds/BlackStarsBig", typeof(Sprite)) as Sprite;
        starTiles = new List<SpriteRenderer>();
        sectorLocations = new List<Vector2>();
        solarSystems = new List<SolarSystem>();
        baseStars = new List<GameObject>();
        Vector2 position = Vector2.zero;

        BuildSectorPoints();
        for(int i = 0; i < poolSize; i++)
        {
            AddStarTile(Vector2.zero, i);
        }

        DisplayStarsAtLocation(sectorLocations[currentSector]);
    }


    public void AddStarTile(Vector2 location, int i)
    {
        int j = Random.Range(0, 10);
        int c = Random.Range('A', 'Z');
        GameObject tile = new GameObject("Sector "+j+"-"+(char)c+i);
        tile.transform.position = location;
        tile.transform.SetParent(transform);
        tile.AddComponent<SpriteRenderer>();
        tile.GetComponent<SpriteRenderer>().sprite = stars;
        starTiles.Add(tile.GetComponent<SpriteRenderer>());
    }

    public void BuildSectorPoints()
    {
        LoadBaseStars();
        float worldWidth = 1000, worldHeight = 1000;
        Vector2 origin = new Vector2(-worldWidth / 2f, -worldHeight / 2f);
        Vector2 location = Vector2.zero;

        for (int w = 0; w < worldWidth; w += xSize)
        {
            for (int h = 0; h < worldHeight; h += ySize)
            {
                location.Set(origin.x + w, origin.y + h);
                sectorLocations.Add(location);

                Vector2 deltaLocation = new Vector2(Random.Range(-1f, 1), Random.Range(-1f, 1f));
                SolarSystem system = new SolarSystem();
                system.sectorIndex = sectorLocations.Count - 1;
                system.location = location + deltaLocation;
                system.star = Instantiate(baseStars[Random.Range(0, 50)], system.location, Quaternion.identity) as GameObject;
                system.star.transform.SetParent(transform);
                system.star.SetActive(false);
                solarSystems.Add(system);
            }
        }

        currentSector = sectorLocations.Count / 2;
        solarSystems[currentSector].star.SetActive(true);
    }

    void LoadBaseStars()
    {
        for (int i = 0; i < 50; i++)
        {
            baseStars.Add(Resources.Load("Prefabs/Stars/Star" + Random.Range(1, 51), typeof(GameObject)) as GameObject);
        }
    }

    public void ChangeSector(Vector2 origin)
    {
        //solarSystems[lastSector].star.SetActive(false);
        solarSystems[currentSector].star.SetActive(true);
        DisplayStarsAtLocation(origin);
        ChangeToRandomColor();
        Debug.Log("Changing Sector");

    }

    void DisplayStarsAtLocation(Vector2 origin)
    {
        Vector2 location = origin;
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x + xSize, origin.y);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x - xSize, origin.y);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x, origin.y + ySize);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x, origin.y - ySize);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x + xSize, origin.y + ySize);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x + xSize, origin.y - ySize);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x - xSize, origin.y + ySize);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;

        location.Set(origin.x - xSize, origin.y - ySize);
        starTiles[TOP].transform.position = location;
        TOP++; if (TOP >= starTiles.Count) TOP = 0;
    }

    public int DiscoverCurrentSector(Vector2 playerLocation)
    {
        float minDistance = 50000;
        int index = 0;
        //Determine the closest vector2 in sector locations
        for (int i = 0; i < sectorLocations.Count; i++)
        {
            float dist = Vector2.Distance(playerLocation, sectorLocations[i]);
            if (dist < minDistance)
            {
                minDistance = dist;
                index = i;
            }
        }
        return index;
    }
    
    void FixedUpdate()
    {
        if (Time.time > nextSectorCheckTime)
        {
            currentSector = DiscoverCurrentSector(player.transform.position);
            if (currentSector != lastSector) changeSector = true;

            nextSectorCheckTime = Time.time + sectorCheckDelay;
        }

        if (changeColor)
        {
            changeColor = false;
            ChangeToRandomColor();
        }
        if (changeSector)
        {
            changeSector = false;
            ChangeSector(sectorLocations[currentSector]);
            lastSector = currentSector;
        }
        if (incrementSector)
        {
            incrementSector = false;
            currentSector++;
            if (currentSector >= sectorLocations.Count) currentSector = 0;
            changeSector = true;
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
    }

    void ColorizeStars(SpriteRenderer star)
    {
        star.color = Color.Lerp(star.color, targetColor, Time.deltaTime * speed);
    }
}
