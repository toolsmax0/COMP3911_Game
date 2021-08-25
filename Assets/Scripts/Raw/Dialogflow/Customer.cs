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
    }

    public IEnumerator StartCaptureAfterTime(float startTime, float Endtime)
    {

        yield return new WaitForSeconds(startTime);

        script.GetComponent<MicrophoneCapture>().StartCapture();
        //set to active the head hearing icon
        this.transform.Find("isHearing").gameObject.SetActive(true);
        //use this to show certain amount of money
        script.GetComponent<ShowMoney>().ShowAmount(300);
        Debug.Log("Start");
        StartCoroutine(StopCaptureAfterTime(Endtime));
    }

    public IEnumerator StopCaptureAfterTime(float Endtime)
    {

        yield return new WaitForSeconds(Endtime);
        this.transform.Find("isHearing").gameObject.SetActive(false);
        script.GetComponent<MicrophoneCapture>().StopCapture();
        //use this call to empty the money
        script.GetComponent<ShowMoney>().ClearTable();

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
