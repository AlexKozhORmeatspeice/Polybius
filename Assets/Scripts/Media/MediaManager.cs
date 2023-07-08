using System;
using System.Collections;
using System.Collections.Generic;
using Media;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MediaManager : MonoBehaviour
{
    public static MediaManager instance;
    [SerializeField] private List<Meme> _memes;
    
    [Serializable] private struct Media
    {
        public Vibe vibe;
        public int likes;
        public int deslikes;
        public List<String> comments; //max would be 3
    }
    
    [SerializeField] private List<Media> easyToDefineMedia;
    [SerializeField] private List<Media> goodToDefineMedia;
    [SerializeField] private List<Media> hardToDefineMedia;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private enum HardMode { easy, good, hard }

    [SerializeField] private HardMode _hardMode;

    public void SetComboCards()
    {
        List<Media> nowMedias = new List<Media>();
        switch (_hardMode)
        {
            case HardMode.easy:
                nowMedias = easyToDefineMedia;
                break;
            case HardMode.good:
                nowMedias = goodToDefineMedia;
                break;
            case HardMode.hard:
                nowMedias = hardToDefineMedia;
                break;
        }

        foreach (Meme meme in _memes)
        {
            Media nowMedia = nowMedias[Random.Range(0, 3)];
           
            meme.clickable = true;
            meme.SetStats(nowMedia.comments, nowMedia.likes, nowMedia.deslikes, nowMedia.vibe);
        }
    }

    public void SetAllUnactive()
    {
        
        foreach (Meme meme in _memes)
        {
            meme.clickable = false;
            meme.SetStats(new List<string>{"", "", ""}, 0, 0, Vibe.noVibe);
        }
    }
}
