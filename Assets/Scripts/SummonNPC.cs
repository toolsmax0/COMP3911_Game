using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonNPC : MonoBehaviour
{
    public GameObject NPC;
    public Transform SPoint;
    public int NumNPC;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(NPC,SPoint);
        NumNPC++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
