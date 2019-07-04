using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollingbg : MonoBehaviour
{
    public GameObject bg;
    public bool spawn = true;
    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            Invoke("SpawnBg", 5);
            spawn = false;
        }
    }

    public void SpawnBg()
    {
        spawn = true;
        Instantiate(bg, bg.transform.localPosition + new Vector3(20, 0, 0), Quaternion.identity);
    }
}
