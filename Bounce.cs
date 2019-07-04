using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float upLaunchForce;
    public float rightLaunchForce;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * upLaunchForce, ForceMode.VelocityChange);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * rightLaunchForce, ForceMode.VelocityChange);
        }
    }
}
