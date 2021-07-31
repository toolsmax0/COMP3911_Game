using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private Dooranimated door;

    private const float _maxDistance = 5000;
    private Animator animator;
    private bool opened = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
            if (hit.transform.tag == "Door" && Input.GetMouseButtonDown(0))
            {
                if (opened == false)
                {
                    opened = true;
                    door.OpenDoor();
                }
                else
                {
                    opened = false;
                    door.CloseDoor();
                }
        }
        
    }
}
