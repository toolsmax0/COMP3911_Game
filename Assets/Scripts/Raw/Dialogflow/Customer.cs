using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [HideInInspector]
    // [RequireComponent(typeof(Outline))]
    public GameObject script;

    void Start()
    {
        // StartCoroutine(StartCaptureAfterTime(0f, 4f));
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        //     script.GetComponent<MicrophoneCapture>().StartCapture();
        // if (Input.GetKeyUp(KeyCode.Space))
        //     script.GetComponent<MicrophoneCapture>().StopCapture();
        if (Dialogflow.state == Dialogflow.State.exit)
        {
            Dialogflow.state = 0;
            GameObject.Find("Script").GetComponent<ShowMoney>().ClearTable();
            StartCoroutine(Leave(3));
        }
    }

    // public IEnumerator StartCaptureAfterTime(float startTime, float Endtime)
    // {
    //     yield return new WaitForSeconds(startTime);
    //     script.GetComponent<MicrophoneCapture>().StartCapture();
    //     //set to active the head hearing icon
    //     //use this to show certain amount of money
    //     script.GetComponent<ShowMoney>().ShowAmount(300, greedy: false);
    //     Debug.Log("Start");
    //     StartCoroutine(StopCaptureAfterTime(Endtime));
    // }
    // public IEnumerator StopCaptureAfterTime(float Endtime)
    // {
    //     yield return new WaitForSeconds(Endtime);
    //     script.GetComponent<MicrophoneCapture>().StopCapture();
    //     //use this call to empty the money
    //     script.GetComponent<ShowMoney>().ClearTable();
    //     Debug.Log("Stop");
    // }
    //Re: this logic should be moved into AI part
    public IEnumerator Leave(float time)
    {
        this.GetComponent<BasicAI>().target =
            GameObject.FindGameObjectWithTag("Finish").transform;
        Queuing.getInstance().DeQueue();
        yield return new WaitForSeconds(time);
        Destroy (gameObject);
    }

    void OnMouseDown()
    {
        if (Queuing.getInstance().Peek() == gameObject)
        {
            Dialogflow.customer = gameObject;
            int n = UnityEngine.Random.Range(1, 21) * 10;
            Dialogflow.money = n;
            GameObject.Find("Script").GetComponent<ShowMoney>().ShowAmount(n);
        }
    }

    private void OnDestroy()
    {
        SummonNPC.NumNPC--;
    }

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
