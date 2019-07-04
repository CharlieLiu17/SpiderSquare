using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceIndicator : MonoBehaviour
{
    public GameObject player;
    public GameObject distanceIndicator;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > distance)
        {
            distanceIndicator.SetActive(true);
        }
        else if(player.transform.position.y < distance)
        {
            distanceIndicator.SetActive(false);
        }
    }
}
