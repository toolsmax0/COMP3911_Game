using UnityEngine;
using System.Collections;

public class RayDetect : MonoBehaviour
{
    public Camera camera;
    public GameObject Player;

    private Vector3 offset = new Vector3(0, 0, 1);//offset, 深度为相机前方1m
    private Transform prevLifted = null;
    private Transform crtLifted = null;
    private bool lifting = false;

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

            // Do something with the object that was hit by the raycast.
            Debug.Log(objectHit.name);
            //determine if E is presssed
            if (Input.GetKey(KeyCode.E))
            {
                //determine if the object is rigidbody
                if (objectHit.GetComponent<Rigidbody>() != null && !lifting)
                {
                    lifting = true;//avoid lift two object at the same time
                    prevLifted = objectHit;
                    crtLifted = objectHit;
                }
                if (WithInRange(crtLifted.transform.position, Player.transform.position, 2))
                {
                    //change the out glow color of the object hit
                    crtLifted.GetComponent<Outline>().OutlineColor = Color.green;

                    //get the location from screen coordinate to world coordinate
                    Vector3 transformed = camera.ScreenToWorldPoint(center + offset);
                    //disable rotation
                    crtLifted.transform.rotation = Quaternion.identity;
                    //temporary disable gravity
                    crtLifted.GetComponent<Rigidbody>().useGravity = false;
                    crtLifted.transform.position = transformed;
                }
            }
        }
        if (prevLifted != null)
        {
            if (!WithInRange(prevLifted.transform.position, Player.transform.position, 2) || (!Input.GetKey(KeyCode.E)))
            {
                //release the object
                lifting = false;
                prevLifted.GetComponent<Rigidbody>().useGravity = true;
                prevLifted.GetComponent<Outline>().OutlineColor = Color.white;

            }
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