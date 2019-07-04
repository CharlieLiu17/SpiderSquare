using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 0));
    }
}
