using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscClicked : MonoBehaviour
{
    private AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            sound.Play();
        }
    }
}
