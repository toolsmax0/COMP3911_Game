using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Dialogflow : MonoBehaviour
{
    public GameObject customer;
    //Detect intent with audio input(speech) using Dialogflow API
    //Reference: https://cloud.google.com/dialogflow/es/docs/how/detect-intent-audio#detect-intent-audio-drest
    public IEnumerator Request(byte[] speech)
    {
        UnityWebRequest req = new UnityWebRequest("https://dialogflow.googleapis.com/v2/projects/" + this.GetComponent<GoogleOAuth>().projectID + "/agent/sessions/34563:detectIntent", "POST");
        RequestBody requestBody = new RequestBody
        {
            queryInput = new QueryInput
            {
                audioConfig = new AudioConfig
                {
                    audioEncoding = AudioEncoding.AUDIO_ENCODING_UNSPECIFIED,
                    sampleRateHertz = 24000,
                    languageCode = "zh-HK"
                }
            },
            inputAudio = System.Convert.ToBase64String(speech)
        };

        string jsonRequestBody = JsonUtility.ToJson(requestBody, true);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRequestBody);
        req.SetRequestHeader("Authorization", "Bearer " + this.GetComponent<GoogleOAuth>().token);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
            Debug.Log(req.downloadHandler.text);
        }
        else
        {
            byte[] resultbyte = req.downloadHandler.data;
            string result = System.Text.Encoding.UTF8.GetString(resultbyte);
            ResponseBody content = (ResponseBody)JsonUtility.FromJson<ResponseBody>(result);
            Debug.Log(content.queryResult.queryText);
            Debug.Log(content.queryResult.fulfillmentText);
            if (content.queryResult.fulfillmentText != null)
            {
                // if (content.queryResult.intent.displayName == "q1")
                {
                    StartCoroutine(this.GetComponent<TextToSpeech>().Request(content.queryResult.fulfillmentText)); //Text-to-Speech Request
                    StartCoroutine(customer.GetComponent<Customer>().StartCaptureAfterTime(3,4));
                }
                if (content.queryResult.intent.displayName == "q2")
                {
                    StartCoroutine(this.GetComponent<TextToSpeech>().Request(content.queryResult.fulfillmentText));
                    customer.transform.Rotate(0f, -90f, 0.0f);
                    // customer.GetComponent<Customer>().anim.Play("Walk");
                    // customer.GetComponent<Customer>().walk = true;
                }
            }
            else
            {
                customer.transform.Rotate(0f, 180f, 0.0f);
                // customer.GetComponent<Customer>().anim.Play("Walk");
                // customer.GetComponent<Customer>().walk = true;
            }
        }
        req.Dispose();
    }

    [Serializable]
    public class RequestBody
    {
        public QueryInput queryInput;
        public string inputAudio;
    }

    [Serializable]
    public class QueryInput
    {
        public AudioConfig audioConfig;
    }

    [Serializable]
    public class AudioConfig
    {
        public AudioEncoding audioEncoding;
        public int sampleRateHertz;
        public String languageCode;
        public String[] phraseHints;
    }

    [Serializable]
    public enum AudioEncoding
    {
        AUDIO_ENCODING_UNSPECIFIED,
        AUDIO_ENCODING_LINEAR_16,
        AUDIO_ENCODING_FLAC,
        AUDIO_ENCODING_MULAW,
        AUDIO_ENCODING_AMR,
        AUDIO_ENCODING_AMR_WB,
        AUDIO_ENCODING_OGG_OPUS,
        AUDIO_ENCODING_SPEEX_WITH_HEADER_BYTE
    }

    [Serializable]
    public enum WebhookState
    {
        STATE_UNSPECIFIED,
        WEBHOOK_STATE_ENABLED,
        WEBHOOK_STATE_ENABLED_FOR_SLOT_FILLING
    }

    [Serializable]
    public class ResponseBody
    {
        public string responseId;
        public QueryResult queryResult;
        public Status webhookStatus;
    }

    [Serializable]
    public class QueryResult
    {
        public string queryText;
        public string action;
        public Struct parameters;
        public string fulfillmentText;
        public Message[] fulfillmentMessages;
        public Intent intent;
        public int intentDetectionConfidence;
        public Struct diagnosticInfo;
        public string languageCode;
        public int speechRecognitionConfidence;
        public bool allRequiredParamsPresent;
        public string webhookSource;
        public Struct webhookPayload;
        public Context[] outputContexts;
    }

    [Serializable]
    public class Status
    {
        public int code;
        public string message;
        public System.Object[] details;
    }

    [Serializable]
    public class Intent
    {
        public string name;
        public string displayName;
        public WebhookState webhookState;
        public int priority;
        public bool isFallback;
    }

    [Serializable]
    public class Context
    {
        public string name;
    }

    [Serializable]
    public class Struct
    {
        public Dictionary<string, Value> fields;
    }

    [Serializable]
    public class Value
    {
        public NullValue null_value;
        public double number_value;
        public string string_value;
        public bool bool_value;
        public Struct struct_value;
        public ListValue list_value;

        public void ForBool(bool value)
        {
            this.bool_value = value;
        }

        public void ForString(string value)
        {
            this.string_value = value;
        }

        public void ForNumber(double number)
        {
            this.number_value = number;
        }

        public void ForNull()
        {
            this.null_value = NullValue.null_vaule;
        }

        public void ForStruct(Struct value)
        {
            this.struct_value = value;
        }

        public void ForList(ListValue value)
        {
            this.list_value = value;
        }
    }

    [Serializable]
    public enum NullValue
    {
        null_vaule
    }

    [Serializable]
    public class ListValue
    {
        public Value values;

    }
    [Serializable]
    public class Message
    {
        public Text text;
    }

    [Serializable]
    public class Text
    {
        public string[] text;
    }
}
