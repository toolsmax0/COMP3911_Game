using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class TextToSpeech : MonoBehaviour
{
    //Synthesizes speech synchronously using Text-To-Speech API
    //Reference: https://cloud.google.com/text-to-speech/docs/reference/rest/v1/text/synthesize
    public IEnumerator Request(String fulfillmentText)
    {
        UnityWebRequest req = new UnityWebRequest("https://texttospeech.googleapis.com/v1/text:synthesize", "POST");
        RequestBody requestBody = new RequestBody();
        requestBody.input = new SynthesisInput();
        requestBody.voice = new VoiceSelectionParams();
        requestBody.audioConfig = new AudioConfig();
        requestBody.input.text = fulfillmentText;
        requestBody.voice.languageCode = "cmn-CN";
        requestBody.voice.name = "cmn-CN-Wavenet-B";
        requestBody.voice.ssmlGender = "MALE";
        requestBody.audioConfig.audioEncoding = "LINEAR16";

        string jsonRequestBody = JsonUtility.ToJson(requestBody, true);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRequestBody);
        req.SetRequestHeader("Authorization", "Bearer " + this.GetComponent<GoogleOAuth>().token);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return req.SendWebRequest();

        Debug.Log(req.result);

        if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.downloadHandler.text);
        }
        else
        {
            byte[] resultbyte = req.downloadHandler.data;
            string result = System.Text.Encoding.UTF8.GetString(resultbyte);
            ResponseBody content = (ResponseBody)JsonUtility.FromJson<ResponseBody>(result);
            byte[] newBytes = Convert.FromBase64String(content.audioContent);
            this.GetComponent<AudioSource>().clip = WavUtility.ToAudioClip(newBytes, 0, "wav");
            this.GetComponent<AudioSource>().Play();
        }
        req.Dispose();
    }

    [Serializable]
    public class RequestBody
    {
        public SynthesisInput input;
        public VoiceSelectionParams voice;
        public AudioConfig audioConfig;
    }

    [Serializable]
    public class SynthesisInput
    {
        public String text;
    }

    [Serializable]
    public class VoiceSelectionParams
    {
        public String languageCode;
        public String name;
        public String ssmlGender;
    }

    [Serializable]
    public class AudioConfig
    {
        public String audioEncoding;
    }

    [Serializable]
    public class ResponseBody
    {
        public string audioContent;
    }
}
