using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopicButtonClass : MonoBehaviour // <3
{


    public string topic_name="Name";
    public string icon="Path";
    public float mood_update=1.0f;
    public float engagement_update=-1.0f;
    public Button topicButton;
    public TMP_Text text;
    public GameObject Manager;

    void Start()
    {
        Manager = GameObject.Find("Topic_Manager");
        topicButton = GetComponent<Button>();
        text = GetComponent<TMP_Text>();
        
        
        topicButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Manager.GetComponent<TopicManager>().UpdateByUser(topic_name, mood_update, engagement_update);
    }
    public void DataUpdate(TopicClass topic)
    {
        topic_name = topic.topic_name;
        icon = topic.icon;
        mood_update= topic.mood_update;
        engagement_update= topic.engagement_update;
    }
    public override string ToString()
    {
        return ($"{topic_name}\nmood:{(mood_update>0 ? "+":"")}{mood_update}\ner:{(engagement_update > 0 ? "+" : "")}{engagement_update}");
    }

  

}
