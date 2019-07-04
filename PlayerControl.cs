using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameObject webShooters;
    public GameObject canvas;
    public GameObject cam;
    public AudioSource webSound;
    public AudioSource crash1;
    public AudioSource crash2;
    public float nodeDistance;
    public Vector3 pVel;
    public static bool attached;
    public bool reset;
    public float pitchMin, pitchMax, volumeMin, volumeMax;
    public Transform node;


    private int i;
    private GameObject webShooter;
    private float diffX;
    private bool notCrashed;

    // Start is called before the first frame update
    void Awake()
    {
        attached = false;
        reset = false;
        notCrashed = true;
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetButtonDown("Shoot") && webShooter == null && notCrashed && !PauseMenu.GameIsPaused)
        {
            node = FindClosestNode(NodeSpawner.nodeList);
            if (node.position.x - transform.position.x <= nodeDistance)
            {
                Debug.Log(webShooter);
                pVel = gameObject.GetComponent<Rigidbody>().velocity;
                webShooter = Instantiate(webShooters, transform.position, Quaternion.identity);
                webShooter.SetActive(true);
                PlaySound(webSound);
                attached = true;
            }
        }

        resetShoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn" && notCrashed)
        {
            int num = Random.Range(1, 3);
            if (num == 1)
            {
                PlaySound(crash1);
            }
            else if (num == 2)
            {
                PlaySound(crash2);
            }
            Destroy(cam.GetComponent<AudioSource>());
            Destroy(webShooter);
            notCrashed = false;
            Invoke("Restart", 1);
        }
    }

    private float xCalc(Transform player, Transform node)
    {
        diffX = node.position.x - player.position.x;
        return diffX;
    }

    private void resetShoot()
    {
        if (reset)
        {
            node = null;
            webShooter = null;
            if (webShooter == null)
            {
                reset = false;
            }
        }
    }

    private void PlaySound(AudioSource sound)
    {

        sound.pitch = Random.Range(pitchMin, pitchMax);
        sound.volume = Random.Range(volumeMin, volumeMax);
        sound.Play();
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(webShooter);
    }

    private Transform FindClosestNode(List<Transform> nodeList)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Transform nodePosition in nodeList)
        {
            Vector3 directionToTarget = nodePosition.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if( dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = nodePosition;
            }
        }
        return bestTarget;
    }
}
