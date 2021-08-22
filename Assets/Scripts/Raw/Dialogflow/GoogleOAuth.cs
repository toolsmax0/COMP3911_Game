using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleOAuth : MonoBehaviour
{
    //Google OAuth 2.0 Authorization using service account with JWT
    //Reference:https://developers.google.com/identity/protocols/oauth2#serviceaccount
    //Place the p12 key file in:
    //Unity editor: <path to project folder>/Assets
    //Windows build: <path to executablename_Data folder>
    //MAC build: <path to player app bundle>/Contents

    [HideInInspector]
    public string token;
    public string projectID;
    public string serviceAccountID;
    public string p12Key;
    
    void Start()
    {
        StartCoroutine(Request(serviceAccountID +"@"+ projectID +".iam.gserviceaccount.com", Application.dataPath + "/" + p12Key));
    }

    IEnumerator Request(string serviceAccount, string p12Key)
    {
        //Create and sign JWT
        RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)new X509Certificate2(p12Key, "notasecret").PrivateKey;
        JwtObject jwtObject = new JwtObject
        {
            iss = serviceAccount,
            scope = "https://www.googleapis.com/auth/dialogflow https://www.googleapis.com/auth/cloud-platform", //Dialogflow & Text-to-Speech API
            aud = "https://www.googleapis.com/oauth2/v4/token",
            exp = DateTimeOffset.Now.ToUnixTimeSeconds() + 5,
            iat = DateTimeOffset.Now.ToUnixTimeSeconds(),
        };
        string jwtHeader = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9";
        string jwtClaimSet = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonUtility.ToJson(jwtObject)));
        string jwtSignature = Convert.ToBase64String(rsa.SignData(Encoding.UTF8.GetBytes($"{jwtHeader}.{jwtClaimSet}"), "SHA256"));

        //Use JWT to request token
        UnityWebRequest req = UnityWebRequest.Post("https://oauth2.googleapis.com/token", new Dictionary<string, string>
        {
            ["grant_type"] = "urn:ietf:params:oauth:grant-type:jwt-bearer",
            ["assertion"] = $"{jwtHeader}.{jwtClaimSet}.{jwtSignature}"
        });
        req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
       
        yield return req.SendWebRequest();

        //Token response
        if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(req.responseCode);
            Debug.Log(req.downloadHandler.text);
        }
        else
        {    
            var res = JsonUtility.FromJson<JwtResponse>(req.downloadHandler.text);
            token = res.access_token;
        }
        req.Dispose();
    }

    public class JwtObject
    {
        public string iss;
        public string scope;
        public string aud;
        public long exp;
        public long iat;
    }

    public class JwtResponse
    {
        public string access_token;
        public int expires_in;
        public string token_type;
    }
}