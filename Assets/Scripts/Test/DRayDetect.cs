// deprecated
// using UnityEngine;
// using System.Collections;

// public class RayDetect : MonoBehaviour
// {
//     public Camera camera;
//     public GameObject Player;

//     private bool lifted = false;
//     private Transform prevLifted = null;
//     private Vector3 offset = new Vector3(0, 0, 0.5f); //offset, 深度为相机前方1m


//     void Start()
//     {
//         //lock the mouse 
//         Cursor.lockState = CursorLockMode.Locked;
//     }
//     void FixedUpdate()
//     {
//         RaycastHit hit;
//         //center of screen
//         Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
//         Ray ray = camera.ScreenPointToRay(center);

//         if (Physics.Raycast(ray, out hit))
//         {
//             //the hitted object
//             Transform objectHit = hit.transform;

//             //determine if the object is rigidbody
//             if (objectHit.GetComponent<Rigidbody>() != null)
//             {
//                 //change the out glow color of the object hit
//                 // objectHit.GetComponent<Outline>().OutlineColor = Color.green;
//                 //determine if the object within the trigger range (2m)
//                 if (Input.GetKeyDown(KeyCode.E) && WithInRange(objectHit.transform.position, Player.transform.position, 3))
//                 {
//                     // Do something with the object that was hit by the raycast.
//                     Debug.Log(objectHit.name);
//                     // determine if E is presssed
//                     //toggle lift status
//                     lifted = !lifted;
//                     //update obj according to the lifted status
//                 }
//             }
//             liftObj(objectHit, center);
//         }
//     }

//     bool WithInRange(Vector3 position1, Vector3 position2, float range)
//     {
//         //unit: meter
//         Vector3 diff = position1 - position2;
//         float distance = diff.sqrMagnitude;
//         return distance < range * range;
//     }
//     private void liftObj(Transform objectHit, Vector3 center)
//     {
//         if (this.lifted && objectHit.GetComponent<Rigidbody>() != null)
//         {
//             prevLifted = objectHit;
//             //change the out glow color of the object holding
//             objectHit.GetComponent<Outline>().OutlineColor = Color.blue;

//             //center of the camera
//             Vector3 transformed = camera.ScreenToWorldPoint(center + this.offset);
//             //move the object together with player
//             objectHit.transform.position = Player.transform.position + new Vector3(1, 1, 1);
//             //constrain the movement of the object 
//             // objectHit.transform.position = new Vector3(Mathf.Clamp(transformed.x, 0, 1), Mathf.Clamp(transformed.y, 0, 1), Mathf.Clamp(transformed.z, 0, 1));

//             //freeze the rotation
//             objectHit.transform.rotation = Quaternion.identity;
//             //disable gravity
//             objectHit.GetComponent<Rigidbody>().useGravity = false;
//             //disable the collider
//             objectHit.GetComponent<Collider>().enabled = false;
//             //drag the object to the center of screen
//             objectHit.transform.position = transformed;
//         }
//         else
//         {
//             //change back the out glow color of the object holding
//             if (prevLifted != null)
//             {
//                 objectHit.GetComponent<Collider>().enabled = true;
//                 prevLifted.GetComponent<Rigidbody>().useGravity = true;
//                 prevLifted.GetComponent<Outline>().OutlineColor = Color.white;
//             }
//         }
//     }
// }