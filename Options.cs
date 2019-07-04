using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject main;
    public GameObject option;

    public void OptionButton()
    {
        main.SetActive(false);
        option.SetActive(true);
    }
}
