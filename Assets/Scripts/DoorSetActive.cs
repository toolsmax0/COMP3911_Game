using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour
{
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    public void ClsoeDoor()
    {
        gameObject.SetActive(true);
    }
}
