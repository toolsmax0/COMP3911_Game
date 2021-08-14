using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
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

    public IEnumerator Leave(float time)
    {
        this.GetComponent<BasicAI>().target =
            GameObject.FindGameObjectWithTag("Finish").transform;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
