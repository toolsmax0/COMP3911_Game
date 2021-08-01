using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonNPC : MonoBehaviour
{
    public GameObject NPC;

    public static int NumNPC = 0;

    public const int MaxNPC = 5;

    // Start is called before the first frame update
    void Start()
    {

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
                Transform des = GameObject.FindGameObjectWithTag("Player").transform;

                GameObject npc = Instantiate(NPC, transform);
                //set NPC destination
                npc.GetComponent<BasicAI>().target = des;
                NumNPC++;
            }
            yield return new WaitForSeconds(3);
        }
    }
}
