using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgdestroy : MonoBehaviour
{
    GameObject cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.x - transform.position.x >= 40 || cam.transform.position.x - transform.position.x <= -40)
        {
            Destroy(gameObject);
        }
    }
}
