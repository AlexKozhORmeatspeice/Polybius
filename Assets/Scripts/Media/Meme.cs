using System;
using System.Collections;
using System.Collections.Generic;
using Media;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Meme : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> commentsObj;
    [SerializeField] private TMP_Text deslikesObj;
    [SerializeField] private TMP_Text likesObj;
    
    [SerializeField] private Vibe nowVibe;

    private List<string> comments;
    private int cLikes;
    private int cDeslikes;
    public List<AudioClip> cSounds;
    private AudioSource sound;
    public bool clickable;
    
    // Start is called before the first frame update
    void Start()
    {
        clickable = false;
        deslikesObj.text = "Likes\n";
        likesObj.text = "Deslikes\n";
        sound = GetComponent<AudioSource>();

        foreach (var commentObj in commentsObj)
        {
            commentObj.text = "";
        }
    }

    // Update is called once per frame
    public void SetStats(List<string> comments, int cLikes, int cDeslikes, Vibe vibe)
    {
        if (!clickable)
            return;
        this.comments = comments;
        this.cDeslikes = cDeslikes;
        this.cLikes = cLikes;
        this.nowVibe = vibe;
        
        print($"{cLikes}  {cDeslikes} {vibe.ToString()}");   

        deslikesObj.text = $"Deslike\n{this.cDeslikes}";
        likesObj.text = $"Like\n{this.cLikes}";

        int c = 0;
        foreach (var comment in this.comments )
        {
            commentsObj[c].text = comment;
            c++;
        }
    }

    public void OnClick()
    {
        if (!clickable)
            return;
        sound.clip = cSounds[(int)nowVibe];
        sound.Play();
        StartCoroutine(EventManager.instance.CheckStats(nowVibe));
    }

    public void SetUnactive()
    {
        clickable = false;
        deslikesObj.text = "Likes\n";
        likesObj.text = "Deslikes\n";
        
        foreach (var commentObj in commentsObj)
        {
            commentObj.text = "";
        }    
    }
}
