using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [HideInInspector]
    public GameObject script;

    void Start()
    {
        // StartCoroutine(StartCaptureAfterTime(0f, 4f));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator StartCaptureAfterTime(float startTime, float Endtime)
    {
        yield return new WaitForSeconds(startTime);

        script.GetComponent<MicrophoneCapture>().StartCapture();
        Debug.Log("Start");
        StartCoroutine(StopCaptureAfterTime(Endtime));
    }

    public IEnumerator StopCaptureAfterTime(float Endtime)
    {
        yield return new WaitForSeconds(Endtime);

        script.GetComponent<MicrophoneCapture>().StopCapture();
        Debug.Log("Stop");
    }

    //Re: this logic should be moved into AI part
    public IEnumerator Leave(float time)
    {
        this.GetComponent<BasicAI>().target =
            GameObject.FindGameObjectWithTag("Finish").transform;
        Queuing.getInstance().DeQueue();
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        StartCoroutine(Leave(3));
        Debug.Log("Leave");
    }

    private void OnDestroy()
    {
        SummonNPC.NumNPC--;
    }
}