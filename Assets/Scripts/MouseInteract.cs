using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Queuing.getInstance().DeQueue();
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        SummonNPC.NumNPC--;
    }
}
