using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TopicManager : MonoBehaviour //По хорошему его бы разбить на ButtonManager, ThemeManager и SliderManager, но пофиг
{
    public GameObject FirstButton;
    public GameObject SecondButton;
    public GameObject ThirdButton;
    public GameObject CurrentTheme;
    public GameObject SliderManager;
    public List<List<string>> TopicList = new List<List<string>>();
    public List<GameObject> Buttons = new List<GameObject>();
    private Unity.Mathematics.Random RandomGenerator = new Unity.Mathematics.Random(3232);
    void Start()
    {
        FirstButton = GameObject.Find("Next1Theme");
        SecondButton = GameObject.Find("Next1Theme (1)");
        ThirdButton = GameObject.Find("Next1Theme (2)");
        Buttons.Add(FirstButton);
        Buttons.Add(SecondButton);
        Buttons.Add(ThirdButton);
        CurrentTheme = GameObject.Find("1Theme");
        SliderManager = GameObject.Find("Slider_Manager");
        
        for (int i = 1; i < 100; i++)
        {
            TopicList.Add(new List<string> { $"Theme {RandomGenerator.NextInt(1,101)}", $"Path {i}",
                RandomGenerator.NextFloat(-5.0f, 5.0f).ToString("#.#"), RandomGenerator.NextFloat(-5.0f, 5.0f).ToString("#.#") });
        }
        UpdateButtons();
        
    }

    IEnumerator Cooldown()
    {
       
        yield return new WaitForSeconds(5);
       
    }
    public void UpdateByUser(string choice, float mood_upd, float er_upd)
    {

        CurrentTheme.GetComponent<TMP_Text>().text=choice;
        
        SliderManager.GetComponent<SliderManager>().ChangeSliders(mood_upd, er_upd);
        for (int i=0; i<3; i++)
        {
            GameObject btn = Buttons[i];
            btn.GetComponent<TMP_Text>().text = "wait!";
            //btn.GetComponent<TopicButtonClass>().StartCoroutine(btn.GetComponent<TopicButtonClass>().Cooldown());
        }
        StartCoroutine(Cooldown());
        UpdateButtons();
    }
    
    void UpdateButtons()
    {
        List<int> used = new List<int>();
        while (used.Count != 3)
        {
            int index = RandomGenerator.NextInt(0, 100);
            if (!(used.Contains(index)) && used.Count != 3)
            {
                used.Add(index);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject btn = Buttons[i];
            string topic_name = TopicList[used[i]][0];
            string icon = TopicList[used[i]][1];
            float mood_update = (float)Convert.ToDouble(TopicList[used[i]][2]);
            float engagement_update = (float)Convert.ToDouble(TopicList[used[i]][3]);
            btn.GetComponent<TopicButtonClass>().DataUpdate(new TopicClass(topic_name, icon, mood_update, engagement_update));
            btn.GetComponent<TMP_Text>().text = btn.GetComponent<TopicButtonClass>().ToString();
        }
    }
}
