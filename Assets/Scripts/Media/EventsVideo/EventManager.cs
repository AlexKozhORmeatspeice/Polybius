using System;
using System.Collections;
using System.Collections.Generic;
using Media;
using UnityEngine;
using UnityEngine.Video;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip interruption;
    
    [Serializable] private struct Video
    {
        public VideoClip videoClip;
        public float playLength;
        public Event eventStats;
    }
    [Serializable] private struct Event
    {
        public bool isEvent;
        
        public float ifSadVibeF;
        public VideoClip isSadVibeClip;
        
        public float ifFunnyVibeF;
        public VideoClip ifFunnyVibeClip;
        
        public float ifAngryVibeF;
        public VideoClip ifAngryVibeClip;
    }

    [SerializeField] private List<Video> _videos;

    private Event nowEvent;
    private int indVideo;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        indVideo = 0;
        StartCoroutine(PlayNextVideo());
    }

    private IEnumerator PlayNextVideo()
    {
        Video nowVideo = _videos[indVideo];
        
        _videoPlayer.clip = nowVideo.videoClip;
        yield return new WaitForSeconds(nowVideo.playLength);
        

        if (nowVideo.eventStats.isEvent)
        {
            MediaManager.instance.SetComboCards();
            _videoPlayer.Stop();

            nowEvent = nowVideo.eventStats;
        }
        else
        {
            _videoPlayer.clip = interruption;
            yield return new WaitForSeconds(1.0f);
            
            indVideo++;
            if (indVideo <= _videos.Count - 1)
                StartCoroutine(PlayNextVideo());
            
        }
    }

    public IEnumerator CheckStats(Vibe choosedVibe)
    {
        MediaManager.instance.SetAllUnactive();
        switch (choosedVibe)
        {
            case Vibe.Angry:
                _videoPlayer.clip = nowEvent.ifAngryVibeClip;
                SliderManager.instance.ChangeSliders(nowEvent.ifAngryVibeF, 0);
                break; 
            case Vibe.Funny:
                _videoPlayer.clip = nowEvent.ifFunnyVibeClip;
                SliderManager.instance.ChangeSliders(nowEvent.ifFunnyVibeF, 0);
                break;
            case Vibe.Sad:
                _videoPlayer.clip = nowEvent.isSadVibeClip;
                SliderManager.instance.ChangeSliders(nowEvent.ifSadVibeF, 0);
                break;
        }

        yield return new WaitForSeconds((float)_videoPlayer.clip.length);
        
        _videoPlayer.clip = interruption;
        yield return new WaitForSeconds(1.0f);
            
        indVideo++;
        if (indVideo <= _videos.Count - 1)
            StartCoroutine(PlayNextVideo());
    }
    
}
