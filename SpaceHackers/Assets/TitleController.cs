using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour
{
    // Canvas references
    public GameObject titleCanvas;
    public GameObject loadCanvas;
    public GameObject nameCanvas;
    public GameObject raceCanvas;
    public GameObject classCanvas;
    public GameObject shipCanvas;
    public GameObject confirmCanvas;

    void Start()
    {
        // Disable all canvases but title
        titleCanvas.SetActive(true);
        loadCanvas.SetActive(false);
        nameCanvas.SetActive(false);
        raceCanvas.SetActive(false);
        classCanvas.SetActive(false);
        shipCanvas.SetActive(false);
        confirmCanvas.SetActive(false);


        // If any saved games
        if (SaveLoadController.CheckForSaves())
        {
            //Enable load button
        }                
    }
}
