using UnityEngine;
using System.Collections;

public class GetRotationFromPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 playerAngles = player.transform.eulerAngles;
        playerAngles.z = 360 - playerAngles.z;
        transform.eulerAngles = playerAngles;
    }
}
