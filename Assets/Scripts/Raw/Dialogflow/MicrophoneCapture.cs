using UnityEngine;

public class MicrophoneCapture : MonoBehaviour
{
    //Record to audio clip using microphone
    //Reference: https://docs.unity3d.com/ScriptReference/Microphone.html
    private byte[] speech;

    private bool recording;

    public AudioSource audioSource;

    void Start()
    {
        if (Microphone.devices.Length <= 0)
        {
            Debug.Log("Microphone not detected");
        }
        else
        {
            // audioSource = this.GetComponent<AudioSource>();
            Debug.Log (audioSource);
        }
    }

    public void StartCapture()
    {
        if (!recording)
        {
            audioSource.clip = Microphone.Start(null, true, 20, 24000);
            recording = true;
        }
    }

    public void StopCapture()
    {
        if (recording)
        {
            Microphone.End(null);
            recording = false;
            speech = WavUtility.FromAudioClip(audioSource.clip); //Audio clip to byte[]
            if (speech != null)
                StartCoroutine(this.GetComponent<Dialogflow>().Request(speech)); //Dialogflow Request
        }
    }
}
