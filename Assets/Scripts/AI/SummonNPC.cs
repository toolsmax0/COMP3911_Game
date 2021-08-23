using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonNPC : MonoBehaviour
{

    public GameObject[] NPCList;

    public bool canJumpQueue = true; // set to true to enable jump queue event.

    public static int NumNPC = 0;

    public const int MaxNPC = 3;

    public float summonDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("base transform set to" + Queuing.getInstance().baseTransform);
        StartCoroutine("Spawn");
    }



    IEnumerator Spawn()
    {
        while (true)
        {
            float p = (float)NumNPC / MaxNPC;
            if (Random.Range(0f, 1f) > p)
            {
                //randomly select an NPC to spawn
                int npcIndex = Random.Range(0, NPCList.Length);
                GameObject npc = Instantiate(NPCList[npcIndex], transform);
                // temp hard code jump prob to 25%
                Transform dest;
                if (canJumpQueue && NumNPC > 1 && true)
                {
                    Debug.Log("Attemp to jump the queue");
                    dest = Queuing.getInstance().jumpQueue();
                    //to ask an NPC not to jump the queue, EnQueue() shall be called
                    // to make it have the correct behavior.
                }
                else
                {
                    //get the destination position of the queue
                    dest = Queuing.getInstance().EnQueue(npc);
                }

                npc.GetComponent<BasicAI>().target = dest;
                npc.GetComponent<Customer>().script =
                    GameObject.FindGameObjectWithTag("Script");
                NumNPC++;
            }
            yield return new WaitForSeconds(summonDelay);
        }
    }
}
