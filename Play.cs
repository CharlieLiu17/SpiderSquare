using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject in0;
    public GameObject in1;
    public GameObject in2;
    public GameObject in3;

    

    public void PlayButton()
    {
        if (PersistentManagerScript.Instance.instructions == true)
        {
            Debug.Log(PersistentManagerScript.Instance.instructions);
            play1();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void play1()
    {
        Debug.Log("eh");
        in0.SetActive(false);
        in1.SetActive(true);
        Invoke("play2", 5);
    }

    void play2()
    {
        Debug.Log("EHH");
        in1.SetActive(false);
        in2.SetActive(true);
        Invoke("play3", 5);
    }

    void play3()
    {
        in2.SetActive(false);
        in3.SetActive(true);
        Invoke("play4", 3);
    }

    void play4()
    { 
        PersistentManagerScript.Instance.instructions = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
