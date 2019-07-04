using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject cam;
    // Update is called once per frame
    void Update()
    {
        if(cam.transform.position.x >= gameObject.transform.position.x + 40)
        {
            Debug.Log("node did this");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        NodeSpawner.nodeList.Remove(gameObject.transform);
    }
}
