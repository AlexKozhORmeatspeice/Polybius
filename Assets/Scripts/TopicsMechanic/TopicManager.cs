using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TopicManager : MonoBehaviour //�� �������� ��� �� ������� �� ButtonManager, ThemeManager � SliderManager, �� �����
{
    [SerializeField] private Slider slider;
    private bool canChangeTopic;
    
    [SerializeField] private GameObject FirstButton;
    [SerializeField] private GameObject SecondButton;
    [SerializeField] private GameObject ThirdButton;
    [SerializeField] private GameObject CurrentTheme;
    [SerializeField] private GameObject SliderManager;
    private List<List<string>> TopicList = new List<List<string>>();
    
    private List<GameObject> Buttons = new List<GameObject>();
    private Unity.Mathematics.Random RandomGenerator = new Unity.Mathematics.Random(3232);
    void Start()
    {
        canChangeTopic = true;
        
        Buttons.Add(FirstButton);
        Buttons.Add(SecondButton);
        Buttons.Add(ThirdButton);

        
        for (int i = 1; i < 100; i++)
        {
            TopicList.Add(new List<string> { $"Theme {RandomGenerator.NextInt(1,101)}", $"Path {i}",
                RandomGenerator.NextFloat(-5.0f, 5.0f).ToString("#.#"), RandomGenerator.NextFloat(-5.0f, 5.0f).ToString("#.#") });
        }
        UpdateButtons();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Cooldown()
    {
        canChangeTopic = false;
        for (int i = 0; i <= 5; i++)
        {
            slider.value = 5 - i;
            yield return new WaitForSeconds(1);
        }

        canChangeTopic = true;
        UpdateButtons();
    }
    public void UpdateByUser(string choice, float mood_upd, float er_upd)
    {
        CurrentTheme.GetComponent<TMP_Text>().text=choice;
        
        SliderManager.GetComponent<SliderManager>().ChangeSliders(mood_upd, er_upd);
        for (int i=0; i<3; i++)
        {
            GameObject btn = Buttons[i];
            btn.GetComponent<TMP_Text>().text = "wait!";
        }
        StartCoroutine(Cooldown());
        UpdateButtons();
    }
    
    void UpdateButtons()
    {
        if (!canChangeTopic)
            return;
        
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
