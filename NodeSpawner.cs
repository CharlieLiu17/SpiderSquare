using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    public GameObject node;
    public GameObject cam;
    public static List<Transform> nodeList;
    public bool spawnNext;
    public float spawnDistanceX;
    public float spawnDistanceY;

    private Transform firstNodeP;
    private GameObject instNode;
    private Vector3 originalNodeP;
    // Start is called before the first frame update
    void Start()
    {
        firstNodeP = GameObject.FindWithTag("Node").transform;
        originalNodeP = firstNodeP.position;
        spawnNext = false;
        nodeList = new List<Transform>();
        nodeList.Add(firstNodeP);
        Debug.Log(nodeList);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (spawnNext) {
            instNode = Instantiate(node, new Vector3((firstNodeP.x + spawnDistanceX), 
                (originalNodeP.y + Random.Range(-spawnDistanceY, spawnDistanceY)), 1f), Quaternion.Euler(90f, 0f, 0f));
            instNode.SetActive(true);
            firstNodeP = instNode.transform.position;
            spawnNext = false;
        }*/

        if (firstNodeP != null)
        {
            if (cam.transform.position.x >= firstNodeP.position.x)
            {
                instNode = Instantiate(node, new Vector3((firstNodeP.position.x + spawnDistanceX),
                    (originalNodeP.y + Random.Range(-spawnDistanceY, spawnDistanceY)), 1f), Quaternion.Euler(90f, 0f, 0f));
                instNode.SetActive(true);
                firstNodeP = instNode.transform;
                nodeList.Add(instNode.transform);
            }
        }

    }
}
