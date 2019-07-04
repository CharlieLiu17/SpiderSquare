using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSlinging : MonoBehaviour
{
    public int numPoints;
    public float angDrag;
    public GameObject player;
    public GameObject nodeSpawner;
    public float launchMultiplier;

    private int i;
    private Transform node;
    private float diffY;
    private float diffX;
    private float angle;
    private float t;
    private float magnitude;
    private float pMag;
    private Vector3 newPosition;
    private Vector3 newScale;
    // Start is called before the first frame update
    void OnEnable()
    {
        node = player.GetComponent<PlayerControl>().node;
        nodeSpawner = GameObject.Find("NodeSpawner");
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {

        DestroyWeb();
    }

    private void FixedUpdate()
    {

        if (i <= numPoints)
        {
            Scale(player.transform, node);
        }
        if (i == numPoints + 1)
        {
            FixedJoint fj = player.AddComponent(typeof(FixedJoint)) as FixedJoint;
            fj.connectedBody = gameObject.GetComponent<Rigidbody>();
            AddHingeJoint(gameObject, "Node");
            gameObject.GetComponent<HingeJoint>().connectedBody = node.gameObject.GetComponent<Rigidbody>();
            AddFixedJoint(node.gameObject);
            GetComponent<Rigidbody>().velocity = player.GetComponent<PlayerControl>().pVel;
            i++;
        }
    }

    private void Scale(Transform player, Transform node)
    {
        if (node != null)
        {
            angleAdjust(player, node);
            // t is scalar fraction of distance between between player and node
            t = 1 / (float)numPoints;
            //Calculate scalar magnitude between the two points through pythag
            magnitude = CalculateLinearMagnitude(player.position, node.position);
            //Calculate the partial fraction between the two through t
            pMag = magnitude * t;
            newScale = new Vector3(pMag, 0, 0);

            //Calculate new position of scaled object
            //Calculate Vector3 quantity of the two vectors,
            //multiplied by t to calculate partial vector,
            // and / 2 to account for the new part of the prism that shoots from the back
            Vector3 added = (t * i * (node.position - player.position)) / 2; //Future Bug?
            newPosition = transform.position + added;

            transform.localScale += newScale;
            transform.position = newPosition;
            i++;
        }
    }

    private void angleAdjust(Transform player, Transform node)
    {
        diffY = node.position.y - player.position.y;
        diffX = node.position.x - player.position.x;
        angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg;
        Quaternion qAngle = Quaternion.Euler(0f, 0f, angle);
        
        transform.rotation = qAngle;
    }

    private void positionAdjust(Transform player, Transform node)
    {
        newPosition = (node.position - player.position);
        //web.position = 
    }
    private float CalculateLinearMagnitude(Vector3 p0, Vector3 p1)
    {
        float x = (p0.x - p1.x);
        float xx = x * x;
        float y = (p0.y - p1.y);
        float yy = y * y;
        float z = (p0.z - p1.z);
        float zz = z * z;
        float magnitude = Mathf.Sqrt(xx + yy + zz);
        return magnitude;
    }

    private void AddHingeJoint(GameObject obj, string cBody) //string is tag to find cbody at run time
    {
        GameObject cb = GameObject.FindWithTag(cBody);
        obj.AddComponent<HingeJoint>();
        HingeJoint hj = obj.GetComponent<HingeJoint>();
        hj.connectedBody = cb.GetComponent<Rigidbody>();
        hj.anchor = new Vector3(0.5f, 0f, 0f);
        hj.axis = new Vector3(0f, 0f, 1f);
    }

    private void AddFixedJoint(GameObject obj)
    {
        obj.AddComponent<FixedJoint>();
    }

    private void DestroyWeb()
    {
        if (Input.GetButtonDown("Shoot") && !PauseMenu.GameIsPaused && node != null) 
        {
            //nodeSpawner.GetComponent<NodeSpawner>().spawnNext = true;
            PlayerControl.attached = false;
            Destroy(node.gameObject);
            Destroy(player.GetComponent<FixedJoint>());
            player.GetComponent<PlayerControl>().reset = true;
            Destroy(gameObject);
            player.GetComponent<Rigidbody>().velocity *= launchMultiplier;
            ScoreBoard.scoreCounter++;
        }
    }
}
