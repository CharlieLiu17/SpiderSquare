using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 playerxz;
    private Vector3 offset;
    private float origy;
    // Start is called before the first frame update
    void Start()
    {
        origy = player.transform.position.y;
        offset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerxz = new Vector3(player.transform.position.x, origy, player.transform.position.z);
        transform.position = playerxz + offset;
    }
}
