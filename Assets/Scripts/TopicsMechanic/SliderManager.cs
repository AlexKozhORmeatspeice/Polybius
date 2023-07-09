using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static SliderManager instance;
    [SerializeField] private float speed = 1.0003f;
    [SerializeField] private string nextScene; 
    public bool canChange;
    private bool changing;
    
    private float stTime;

    public GameObject mood_slider;
    public GameObject er_slider;
    void Awake()
    {
        if (instance == null)
            instance = this;

        canChange = false;
        stTime = Time.time;
        mood_slider = GameObject.Find("Slider (1)");
        er_slider = GameObject.Find("Slider");
        mood_slider.GetComponent<Slider>().value = CrossSceneInfo.currentMood;
    }

    void Update()
    {
        if (canChange && !changing)
        {
            stTime = Time.time;
            StartCoroutine(LowER());
        }
        else if(!canChange && !changing)
        {
            stTime = Time.time;
        }
    }
    
    public void ChangeSliders(float mood_change, float er_change)
    {
        mood_slider.GetComponent<Slider>().value += (mood_change/10);
        er_slider.GetComponent<Slider>().value += (er_change/10);
        if (er_slider.GetComponent<Slider>().value<=0) { GameOverEvent(); }
    }
   public void GameOverEvent()
   {
        CrossSceneInfo.nextScene = nextScene;
        CrossSceneInfo.currentMood = mood_slider.GetComponent<Slider>().value;
        SceneManager.LoadScene("Loading");
   }

   private IEnumerator LowER()
   {
       changing = true;
       ChangeSliders(0.0f, -1);
       yield return new WaitForSeconds(2.0f);
       
       if (canChange)
       {
           StartCoroutine(LowER());
       }
       else
       {
           changing = false;
       }
   }
   
}
