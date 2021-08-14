using UnityEngine;
using System.Collections.Generic;

public class Queuing
{
    // Start is called before the first frame update

    public Transform baseTransform; // the first place
    private Vector3 offset;// the distance between each queuing places

    private Transform rear;
    // private Queue<Transform> q;
    private Queue<GameObject> npcQueue;

    private static Queuing instance;

    Queuing()
    {
        baseTransform = GameObject.FindGameObjectWithTag("Wait").transform;
        offset = new Vector3(0, 0, 1.5f);
        npcQueue = new Queue<GameObject>();
        rear = new GameObject().transform;
        rear.position = baseTransform.position - offset;
    }

    public static Queuing getInstance()
    {
        if (instance == null)
        {
            instance = new Queuing();
        }
        return instance;
    }




    public Transform EnQueue(GameObject npc)
    {
        rear.position += offset;
        npcQueue.Enqueue(npc);
        Debug.Log("EnQueue at rear = " + rear.position);

        //the destination of the incoming npc
        Transform dest = new GameObject().transform;
        dest.position = rear.position;
        //random x-axis noise 
        dest.position += new Vector3(Random.Range(-0.1f, 0.1f), 0, 0);
        return dest;
    }

    public void DeQueue()
    {
        if (npcQueue.Count > 0)
        {
            npcQueue.Dequeue();
        }

        rear.position -= offset;

        foreach (GameObject npc in npcQueue)
        {
            //move forward
            npc.GetComponent<BasicAI>().target.position -= offset;
        }
    }

    // Update should be called once an event has occur
}
