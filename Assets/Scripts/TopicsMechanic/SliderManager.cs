using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    GameObject mood_slider;
    GameObject er_slider;
    void Start()
    {
        mood_slider = GameObject.Find("Slider (1)");
        er_slider = GameObject.Find("Slider");
    }

    public void ChangeSliders(float mood_change, float er_change)
    {
        mood_slider.GetComponent<Slider>().value += (mood_change/10);
        er_slider.GetComponent<Slider>().value += (er_change/10);
        if (mood_slider.GetComponent<Slider>().value == 0 || er_slider.GetComponent<Slider>().value==0) { GameOverEvent(); }
    }
   public void GameOverEvent()
    {
        Debug.Log("Game over, man! >:3");
    }
}
