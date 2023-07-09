using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonClicked : MonoBehaviour
{
    private AudioSource sound;
    private Button btn;
    void Start()
    {
        btn=GetComponent<Button>();
        sound=GetComponent<AudioSource>();
        btn.onClick.AddListener(DoSound);
    }
    void DoSound()
    {
        sound.Play();
    }
    
    
}
