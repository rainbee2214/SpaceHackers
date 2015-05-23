using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Star : MonoBehaviour
{
    float radius;
    int numberOfPlanets;

    List<GameObject> planets;

    void Awake()
    {
        //Get the star radius from the collider
        radius = GetComponent<CircleCollider2D>().radius * 50;
        GetComponent<CircleCollider2D>().radius = (radius / 50) * 1.25f;
        SetupStar();
    }

    void Update()
    {

    }

    void SetupStar()
    {
        numberOfPlanets = (int)radius / 18;
        GetPlanets();
    }

    void GetPlanets()
    {
        planets = new List<GameObject>();
        PlanetGenerator.LoadPlanets();

        Vector3 location = Vector3.zero;
        float r = 0f;

        for (int i = 0; i < numberOfPlanets; i++)
        {
            r = Random.Range(radius/50, radius/5);
            location.Set(r, location.y, -1f);
            planets.Add(Instantiate(PlanetGenerator.GetPlanet(), location, Quaternion.identity) as GameObject);
            planets[i].transform.SetParent(transform);
            planets[i].name = "Planet" + i;
        
        }
    }
}
