using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopicButtonClass : MonoBehaviour // <3
{
    public string topic_name="Name";
    public Sprite icon;
    public float mood_update=1.0f;
    public float engagement_update=-1.0f;
    public Button topicButton;
    public TMP_Text text;
    public GameObject Manager;
    public bool canChangeTopic;
    public AudioSource sound;
    public List<AudioClip> sounds;
    private bool isPlaying;
    void Start()
    {
        Manager = GameObject.Find("Topic_Manager");
        sound = GetComponent<AudioSource>();
        topicButton = GetComponent<Button>();
        text = GetComponent<TMP_Text>();
        canChangeTopic = false;
        isPlaying = false;
        topicButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (canChangeTopic)
        {
            sound.clip = sounds[1];
            sound.volume = 1f;
            Manager.GetComponent<TopicManager>().UpdateByUser(topic_name, mood_update, engagement_update, icon);
        }
        else 
        {   
            sound.clip = sounds[0];
            sound.volume = 0.6f;
        }
        if (!isPlaying)
        { 
            StartCoroutine(DoSound());
           
        }
        
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

  private IEnumerator DoSound()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            sound.Play();
        }
        yield return new WaitForSeconds(0.4f);
        isPlaying = false;
    }

}
