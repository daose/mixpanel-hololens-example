using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mixpanel;

public class Tester : MonoBehaviour
{
    public TextMeshPro text;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
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
}
