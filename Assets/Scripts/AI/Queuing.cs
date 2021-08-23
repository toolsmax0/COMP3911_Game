using System.Collections.Generic;
using UnityEngine;

public class Queuing
{
    // Start is called before the first frame update
    public Transform baseTransform; // the first place


    private Vector3 offset; // the distance between each queuing places

    private Transform rear;

    // private Queue<Transform> q;
    private Queue<GameObject> npcQueue;

    private static Queuing instance;

    private static object dcl = new Object();

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
            lock (dcl)
            {
                if (instance == null) instance = new Queuing();
            }
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

    public GameObject Peek()
    {
        return npcQueue.Peek();
    }

    public Transform jumpQueue()
    {


        Vector3 jmpQueueOffset = new Vector3(0.6f, 0, 1f);
        int queueLen = npcQueue.Count;
        //randomly pick a place to jump
        if (queueLen < 2)
        {
            // if less than two people in queue, raise an error
            Debug.Log("Error: less than two people in queue, cannot jump the queue");
            return null;
        }

        int jumpIndex = Random.Range(0, queueLen - 1);
        Transform dest = new GameObject().transform;
        //copy the value of the dest of the npc at the jump index
        dest.position = npcQueue.ToArray()[jumpIndex].GetComponent<BasicAI>().target.position;
        dest.position += jmpQueueOffset;
        return dest;
    }
}
