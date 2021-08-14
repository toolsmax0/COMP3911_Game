using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonNPC : MonoBehaviour
{
    public GameObject NPC;

    public static int NumNPC = 0;

    public const int MaxNPC = 3;

    public float summonDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("base transform set to" + Queuing.getInstance().baseTransform);
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float p = (float)NumNPC / MaxNPC;
            if (Random.Range(0f, 1f) > p)
            {
                //find player, for test purpose
                // Transform des =
                //     GameObject.FindGameObjectWithTag("Wait").transform;

                GameObject npc = Instantiate(NPC, transform);

                //get the destination position of the queue
                Transform des = Queuing.getInstance().EnQueue(npc);

                npc.GetComponent<BasicAI>().target = des;
                npc.GetComponent<Customer>().script =
                    GameObject.FindGameObjectWithTag("Script");
                Dialogflow.customer = npc;
                NumNPC++;
            }
            yield return new WaitForSeconds(summonDelay);
        }
    }
}
