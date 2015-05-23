using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour
{
    static List<GameObject> planets;

    public static void LoadPlanets()
    {
        planets = new List<GameObject>();
        int i = 1;
        while (i <= 50)
        {
            planets.Add(Resources.Load("Prefabs/Planets/Planet" + i++, typeof(GameObject)) as GameObject);
        }
        Debug.Log(planets[23].name);
    }

    public static GameObject GetPlanet()
    {
        return planets[Random.Range(0, planets.Count)];
    }
}
