using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionReset : MonoBehaviour
{

    private void OnApplicationQuit()
    {
        PersistentManagerScript.Instance.instructions = true;
        Debug.Log(PersistentManagerScript.Instance.instructions);
    }
}
