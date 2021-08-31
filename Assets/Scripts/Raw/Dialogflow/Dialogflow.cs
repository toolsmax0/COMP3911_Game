using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class Dialogflow : MonoBehaviour
{
    private static GameObject _customer = null;
    public static State state;
    public Regex regex = new Regex(@"^我要充值(\d+)元",RegexOptions.Compiled);
    

    public static int money;
    public static GameObject customer{
        get => _customer;
        set{
            if(_customer != null )
            {
                _customer.GetComponent<Customer>().enabled = false;
                _customer?.transform.Find("isHearing").gameObject.SetActive(false);
            }
            _customer=value;
            _customer.GetComponent<Customer>().enabled = true;
            _customer.transform.Find("isHearing").gameObject.SetActive(true);
            state=State.q1;
            money=0;
            DialogflowWebRequest.Refresh();
        }
    }

    public GameObject subtitle;

    //Detect intent with audio input(speech) using Dialogflow API
    //Reference: https://cloud.google.com/dialogflow/es/docs/how/detect-intent-audio#detect-intent-audio-drest
    public IEnumerator Request(byte[] speech)
    {
        //set the content of text mesh pro
        subtitle.GetComponent<TMP_Text>().text = "處理中...";

        // UnityWebRequest req =
        //     new UnityWebRequest("https://dialogflow.googleapis.com/v2/projects/" +
        //         this.GetComponent<GoogleOAuth>().projectID +
        //         "/agent/sessions/34563:detectIntent",
        //         "POST");
        RequestBody requestBody =
            new RequestBody {
                queryInput =
                    new QueryInput {
                        audioConfig =
                            new AudioConfig {
                                audioEncoding =
                                    AudioEncoding.AUDIO_ENCODING_UNSPECIFIED,
                                sampleRateHertz = 24000,
                                languageCode = "zh-CN"
                            }
                    },
                inputAudio = System.Convert.ToBase64String(speech)
            };
        if(state==State.q2p||state==State.exit){
            var prm = new QueryParameters();
            prm.contexts = new Context[1];
            if(state==State.q2p)
                prm.contexts[0]=new Context("payment",3);
            else
                prm.contexts[0]=new Context("exit",3);
            requestBody.queryParams=prm;
        }

        // string jsonRequestBody = JsonUtility.ToJson(requestBody, true);
        // byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRequestBody);
        // req
        //     .SetRequestHeader("Authorization",
        //     "Bearer " + this.GetComponent<GoogleOAuth>().token);
        // req.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        // req.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        var req = DialogflowWebRequest.DetectIntent();
        PackMessage (req, requestBody);
        yield return req.SendWebRequest();

        if (
            req.result == UnityWebRequest.Result.ConnectionError ||
            req.result == UnityWebRequest.Result.ProtocolError
        )
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.error);
            Debug.Log(req.downloadHandler.text);
        }
        else
        {
            byte[] resultbyte = req.downloadHandler.data;
            string result = System.Text.Encoding.UTF8.GetString(resultbyte);
            ResponseBody content =
                (ResponseBody) JsonUtility.FromJson<ResponseBody>(result);
            Debug.Log(content.queryResult.queryText);
            Debug.Log(content.queryResult.fulfillmentText);
            if (content.queryResult.fulfillmentText != null)
            {
                subtitle.GetComponent<TMP_Text>().text =
                    "顧客: " + content.queryResult.fulfillmentText;
                StartCoroutine(this
                    .GetComponent<TextToSpeech>()
                    .Request(content.queryResult.fulfillmentText));
            }
            else
            {
                subtitle.GetComponent<TMP_Text>().text = "";
            }
            Debug.Log(state.ToString());
            string text = content.queryResult.fulfillmentText;
            Match m;
            switch (content.queryResult.intent.displayName)
            {
                case "q1":
                    if (UnityEngine.Random.Range(0f, 1f) > 0.5)
                        state = State.q2p;
                    else 
                        state = State.q2;
                    break;
     
                case "q2":
                    m=regex.Match(text);
                    money=Int32.Parse(m.Groups[1].ToString());
                    state=State.paying;
                    TaskPanel.target=money;
                    // Debug.Log(money);
                    Pay();
                    break;
                case "q2+":
                    state=State.credit;
                    m=regex.Match(text);
                    money=Int32.Parse(m.Groups[1].ToString());
                    TaskPanel.target=money;
                    Debug.Log(money);
                    break;
                case "credit":
                    // StartCoroutine(customer.GetComponent<Customer>().Leave(3));
                    state=State.paying;
                    Pay();
                    break;
                case "paying":
                    Pay();
                    break;
                case "exit":
                    gameObject.GetComponent<ShowMoney>().ClearTable();
                    StartCoroutine(customer.GetComponent<Customer>().Leave(3));
                    break;
                default:
                    subtitle.GetComponent<TMP_Text>().text =
                        "顧客: " + content.queryResult.fulfillmentText;
                    StartCoroutine(this
                        .GetComponent<TextToSpeech>()
                        .Request("我没有听清楚你在说什么。"));
                    break;
            }
        }
        req.Dispose();
    }

    public void Pay()
    {
        var sm = gameObject.GetComponent<ShowMoney>();
        int n = money/50;
        int t = UnityEngine.Random.Range(1,n+1)*50;
        sm.ShowAmount(t);
        money-=t;
        Debug.Log(t+" paid, "+money+" left.");
    }
    public void Pay2()
    {

    }

    public void Start()
    {
        DialogflowWebRequest.endpoint = "https://dialogflow.googleapis.com/v2/";
        DialogflowWebRequest.projectID =
            this.GetComponent<GoogleOAuth>().projectID;
        DialogflowWebRequest.Refresh();
    }
    public enum State{q1,q2,q2p,credit,paying,exit};

    public static class DialogflowWebRequest
    {
        public static string endpoint;

        public static string projectID;

        public static int SessionID;

        public static void Refresh() => SessionID = UnityEngine.Random.Range(0, 65536);

        public static UnityWebRequest DetectIntent()
        {
            return new UnityWebRequest(endpoint +
                "projects/" +
                projectID +
                "/agent/sessions/" +
                SessionID +
                ":detectIntent",
                "POST");
        }

        public static UnityWebRequest CreateContext()
        {
            return new UnityWebRequest(endpoint +
                "projects/" +
                projectID +
                "/agent/sessions/" +
                SessionID +
                "/contexts",
                "POST");
        }
    }

    public void PackMessage(UnityWebRequest req, object obj)
    {
        string jsonRequestBody = JsonUtility.ToJson(obj, true);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRequestBody);
        req
            .SetRequestHeader("Authorization",
            "Bearer " + this.GetComponent<GoogleOAuth>().token);
        req.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        return;
    }

    [Serializable]
    public class Context
    {
        public string name;

        public int lifespanCount;

        public Context(string s) :
            this(s, 1)
        {
        }

        public Context(string s, int t)
        {
            Debug.Log (name);
            lifespanCount = t;
            this.name =
                "projects/" +
                DialogflowWebRequest.projectID +
                "/agent/sessions/" +
                UnityEngine.Random.Range(0, 65535) +
                "/contexts/" +
                s;
        }
    }

    [Serializable]
    public class QueryParameters{
       public Context[] contexts;

    }

    [Serializable]
    public class RequestBody
    {
        public QueryParameters queryParams;
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
