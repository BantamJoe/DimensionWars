using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announce : BehaviourNode
{
    public string text;

    public Announce Initialize(string text)
    {
        this.text = text;
        return this;
    }

    public override IEnumerator<BehaviourStatus> GetEnumerator()
    {
        var textComponent = GameObject.Find("AnnounceText").GetComponent<PostBroadcast>();
        textComponent.Say(text);
        yield break;
    }

}
