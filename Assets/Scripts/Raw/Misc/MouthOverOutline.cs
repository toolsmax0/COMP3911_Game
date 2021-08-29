using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthOverOutline : MonoBehaviour
{
    void OnMouseOver()
    {
        //enable outline glow
        GetComponent<Outline>().enabled = true;
    }

    void OnMouseExit()
    {
        //disable outline glow
        GetComponent<Outline>().enabled = false;
    }
}
