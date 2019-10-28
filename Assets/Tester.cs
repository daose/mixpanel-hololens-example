using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using mixpanel;

public class Tester : MonoBehaviour
{
    public TextMeshPro text;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckInternetConnection());
        Mixpanel.Identify("some-random-user");
    }

    public void OnTrackPress()
    {
        count++;
        text.SetText($"Clicked {count}");

        Value props = new Value();
        props["count"] = count;
        Mixpanel.Track("Clicked", props);
    }

    public void OnFlushPress()
    {
        text.SetText("Flush called");
        Mixpanel.Flush();
    }

    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.google.com");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
            text.SetText("No internet connection");
        }
        else {
            text.SetText("Internet check succeeded");
        }
    }
}
