using UnityEngine;
using System.Collections;

public class RayDetect : MonoBehaviour
{
    public Camera camera;
    public GameObject Player;
    void Start()
    {
        //lock the mouse 
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
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
                if (objectHit.GetComponent<Rigidbody>() != null)
                {
                    //offset, 深度为相机前方1m
                    Vector3 offset = new Vector3(0, 0, 1);
                    Vector3 transformed = camera.ScreenToWorldPoint(center + offset);
                    //move the object together with player
                    // objectHit.transform.position = Player.transform.position + offset;
                    objectHit.transform.position = transformed;
                }

            }

        }
    }
}