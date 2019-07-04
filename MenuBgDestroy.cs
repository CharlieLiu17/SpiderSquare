using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBgDestroy : MonoBehaviour
{
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.unscaledTime * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
