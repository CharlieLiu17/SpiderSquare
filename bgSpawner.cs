using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSpawner : MonoBehaviour
{
    public Transform background;
    public Transform fbg;
    public Transform cam;
    private Transform placeholder;

    private float currentDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDistance <= cam.position.x)
        {
            fbg = Instantiate(background, new Vector3(fbg.position.x + 20, fbg.position.y, fbg.position.z), Quaternion.identity);
            currentDistance += 20;
        }
         if (currentDistance > cam.position.x + 40)
        {
            placeholder =  Instantiate(background, new Vector3(fbg.position.x - 60, fbg.position.y, fbg.position.z), Quaternion.identity);
            fbg.position = placeholder.position + new Vector3(20, 0, 0);
            currentDistance -= 20;
        }
    }
}
