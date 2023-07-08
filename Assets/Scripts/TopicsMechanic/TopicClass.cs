using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicClass : MonoBehaviour 
{
//just a container for data, nothing more :)
    public string topic_name;
    public string icon;
    public float mood_update;
    public float engagement_update;
    public TopicClass(string topic_name, string icon, float mood_update, float engagement_update)
    {
        this.topic_name = topic_name;
        this.icon = icon;
        this.mood_update = mood_update;
        this.engagement_update = engagement_update;
    }
}
