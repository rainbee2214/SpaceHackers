using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Star : MonoBehaviour
{
    const float MAX_SPEED = 0.001f;
    const float MIN_SPEED = 0.005f;

    float radius;
    int numberOfPlanets;

    List<GameObject> planets;
    List<PlanetRotation> planetRotations;

    public bool stop = false;

    void Awake()
    {
        //Get the star radius from the collider
        radius = GetComponent<CircleCollider2D>().radius * 50;
        GetComponent<CircleCollider2D>().radius = (radius / 50) * 1.25f;
        SetupStar();
    }

    void Update()
    {
        if (!stop)
        {
            Vector3 position = Vector3.zero;
            for (int i = 0; i < planetRotations.Count; i++)
            {
                planetRotations[i].Rotate();
            }

        }
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
            r = Random.Range(radius/30, radius/3);
            location.Set(r, location.y, -1f);
            planets.Add(Instantiate(PlanetGenerator.GetPlanet(), location, Quaternion.identity) as GameObject);
            planets[i].transform.SetParent(transform);
            planets[i].name = "Planet" + i;
        }

        planetRotations = new List<PlanetRotation>();
        for (int i = 0; i < planets.Count; i++)
        {
            planetRotations.Add(planets[i].GetComponent<PlanetRotation>());
            planetRotations[planetRotations.Count - 1].radius = planets[planetRotations.Count-1].transform.position.x;
            planetRotations[planetRotations.Count - 1].theta = Random.Range(0, Mathf.PI * 2);
            planetRotations[planetRotations.Count - 1].speed = Random.Range(MIN_SPEED, MAX_SPEED);
        }
    }
}
