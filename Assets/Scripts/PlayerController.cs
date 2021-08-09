using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Transform transform;
    public Transform camera;
    public float moveSpeed = 5f;
    public float rotateSpeed = 50f;
    float xRotation = 0;
    float yRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        float adValue = Input.GetAxis("Horizontal");
        float wsValue = Input.GetAxis("Vertical");
        var moveDirection = (Vector3.forward * wsValue) + (Vector3.right *
       adValue);
        transform.Translate(moveDirection.normalized * moveSpeed *
       Time.deltaTime, Space.Self);
        //Input.GetAxis("MouseX")
        xRotation -= Input.GetAxis("Mouse X") * 5f;
        yRotation += Input.GetAxis("Mouse Y") * 5f;
        Quaternion camera_rotation = Quaternion.Euler(-yRotation, -xRotation,
       0);
        Quaternion trans_rotation = Quaternion.Euler(0, -xRotation, 0);
        camera.rotation = camera_rotation;
        transform.rotation = trans_rotation;
    }
}