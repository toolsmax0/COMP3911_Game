using UnityEngine;
using System.Collections;

public class RayDetect : MonoBehaviour
{
    public Camera camera;
    public GameObject Player;

    private Vector3 offset = new Vector3(0, 0, 1);//offset, 深度为相机前方1m
    private Transform prevLifted = null;

    void Start()
    {
        //lock the mouse 
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        //center of screen
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = camera.ScreenPointToRay(center);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            //change the out glow color of the object hit
            //todo

            // Do something with the object that was hit by the raycast.
            Debug.Log(objectHit.name);
            //determine if E is presssed
            if (Input.GetKey(KeyCode.E))
            {
                //determine if the object is rigidbody
                if (objectHit.GetComponent<Rigidbody>() != null && WithInRange(objectHit.transform.position, Player.transform.position, 2))
                {
                    prevLifted = objectHit;
                    Vector3 transformed = camera.ScreenToWorldPoint(center + offset);
                    //move the object together with player
                    // objectHit.transform.position = Player.transform.position + offset;
                    //disable rotation
                    objectHit.transform.rotation = Quaternion.identity;
                    //temporary disable gravity
                    objectHit.GetComponent<Rigidbody>().useGravity = false;
                    objectHit.transform.position = transformed;
                }
            }
        }
        if (prevLifted != null)
        {
            if (!WithInRange(prevLifted.transform.position, Player.transform.position, 2) || (!Input.GetKey(KeyCode.E)))
                //release the object
                prevLifted.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    bool WithInRange(Vector3 position1, Vector3 position2, float range)
    {
        //unit: meter
        Vector3 diff = position1 - position2;
        float distance = diff.sqrMagnitude;
        return distance < range * range;
    }
}