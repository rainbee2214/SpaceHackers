﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    //[HideInInspector]
    public GameObject player;

    [HideInInspector]
    public MiniGameController miniGameController;

    #region Properties

    int shieldCount = 3;
    public int ShieldCount
    {
        get { return shieldCount; }
        set { shieldCount += value; }
    }

    int junk;
    public int Junk
    {
        get { return junk; }
        set { junk += value; }
    }

    int metals;
    public int Metals
    {
        get { return metals; }
        set { metals += value; }
    }

    int organics;
    public int Organics
    {
        get { return organics; }
        set { organics += value; }
    }

    int crystals;
    public int Crystals
    {
        get { return crystals; }
        set { crystals += value; }
    }

    int people;
    public int People
    {
        get { return people; }
        set { people += value; }
    }

    string playerName = "Bob";
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    int shipType = 0;
    public int ShipType
    {
        get { return shipType; }
        set { shipType = value; }
    }

    int shipColor = 0;
    public int ShipColor
    {
        get { return shipColor; }
        set { shipColor = value; }
    }

    int raceType = 0;
    public int RaceType
    {
        get { return raceType; }
        set { raceType = value; }
    }

    bool playerDead = false;
    public bool PlayerDead
    {
        get { return playerDead; }
        set { playerDead = value; }
    }

    string currentPlanetName = "";
    public string CurrentPlanetName
    {
        get { return currentPlanetName; }
        set { currentPlanetName = value; }
    }

    int currentPlanetCrystals = 0;
    public int CurrentPlanetCrystals
    {
        get { return currentPlanetCrystals; }
        set { currentPlanetCrystals = value; }
    }

    int currentPlanetOrganics = 0;
    public int CurrentPlanetOrganics
    {
        get { return currentPlanetOrganics; }
        set { currentPlanetOrganics = value; }
    }

    int currentPlanetMetals = 0;
    public int CurrentPlanetMetals
    {
        get { return currentPlanetMetals; }
        set { currentPlanetMetals = value; }
    }

    int currentPlanetPeople = 0;
    public int CurrentPlanetPeople
    {
        get { return currentPlanetPeople; }
        set { currentPlanetPeople = value; }
    }

    int currentPlanetJunk = 0;
    public int CurrentPlanetJunk
    {
        get { return currentPlanetJunk; }
        set { currentPlanetJunk = value; }
    }

    float currentPlanetRadius;
    public float CurrentPlanetRadius
    {
        get { return currentPlanetRadius; }
        set { currentPlanetRadius = value; }
    }

    Vector2 currentPlanetLocation;
    public Vector2 CurrentPlanetLocation
    {
        get { return currentPlanetLocation; }
        set { currentPlanetLocation = value; }
    }

    Vector2 startingLocation;
    public Vector2 StartingLocation
    {
        get { return startingLocation; }
        set { startingLocation = value; }
    }
    #endregion

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        miniGameController = GetComponentInChildren<MiniGameController>();
    }

    public void StartMiniGame(Vector3 cameraPosition, Vector3 planetLocation, float radius,
                            string currentName, int crystals, int organics, int metals, int people, int junk)
    {
        controller.StartingLocation = cameraPosition;
        controller.CurrentPlanetLocation = planetLocation;
        controller.player.GetComponent<RotateShip>().StartOrbit();
        controller.CurrentPlanetRadius = radius;
        controller.UpdateCurrentPlanetResources(currentName, crystals, organics, metals, people, junk);

        Camera.main.GetComponent<CameraFollow>().pause = true;
    }

    public void StopMiniGame()
    {
        controller.player.GetComponent<RotateShip>().StopOrbit();
        Camera.main.GetComponent<CameraFollow>().pause = false;
    }



    void Update()
    {
        if (Application.loadedLevelName == "Level" && player == null) player = GameObject.FindGameObjectWithTag("Player");
        //When the game over scene is loaded, turn the main camera off
        //When the setup scene is loaded, turn the main camera back on
        if (playerDead && Application.loadedLevelName == "Level")
        {
            playerDead = false;
            Debug.Log("Loading game over");
            Application.LoadLevel("GameOver");
        }

    }

    public void UpdateCurrentPlanetResources(string planetName, int cc, int oc, int mc, int pc, int jc)
    {
        currentPlanetName = planetName;
        currentPlanetCrystals = cc;
        currentPlanetJunk = jc;
        currentPlanetMetals = mc;
        currentPlanetOrganics = oc;
        currentPlanetPeople = pc;
    }
}
