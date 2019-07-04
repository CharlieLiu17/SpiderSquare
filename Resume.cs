using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<PauseMenu>().Resume();
    }
}
