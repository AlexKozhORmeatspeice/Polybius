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
    public static TopicManager instance;
    
    [SerializeField] private Slider slider;
    private bool canChangeTopic;
    
    [SerializeField] private GameObject FirstButton;
    [SerializeField] private GameObject SecondButton;
    [SerializeField] private GameObject ThirdButton;
    [SerializeField] private GameObject CurrentTheme;
    [SerializeField] private GameObject SliderManager;
    [SerializeField] private GameObject HeaderManager;
    [SerializeField] private GameObject NewsManager;
    [SerializeField] private GameObject PictureManager;


    public List<Sprite> picturesList;
    private List<string> topics = new List<string> {"anime :(", "blogger!", "wow,kitty!<3", "city news",
    "games!!", "top 10 lifehacks", "political news", "wow look i'm rich!!", "social problems", "do you like hurt other people?"};
    private List<float> mood_updates = new List<float> {-5f, 3f, 5f, -3f, 4.5f, 3.2f, -4.3f, -3.2f, -3.9f, -5f};
    private List<float> er_update = new List<float> { -7.8f, 8.5f, 10f, -7.2f, 9.2f, -9.3f, -8.8f, 7.9f, 7.1f, -8f };
    private List<TopicClass> TopicList = new List<TopicClass>();


    private List<GameObject> Buttons;
    private Unity.Mathematics.Random RandomGenerator = new Unity.Mathematics.Random(3232);
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        slider = GameObject.Find("Time").GetComponent<Slider>();
        canChangeTopic = true;
        slider.maxValue = 3;
        
        Buttons = new List<GameObject>();
        Buttons.Add(FirstButton);
        Buttons.Add(SecondButton);
        Buttons.Add(ThirdButton);
        for (int i = 0; i < 3; i++)
        {
            GameObject btn = Buttons[i];
            btn.GetComponent<TMP_Text>().text = "wait!";
        }

        canChangeTopic = false;
        foreach (GameObject btn in Buttons)
        {
            btn.GetComponent<TopicButtonClass>().canChangeTopic = false;
        }
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Cooldown()
    {
        canChangeTopic = false;
        foreach (GameObject btn in Buttons)
        {
            btn.GetComponent<TopicButtonClass>().canChangeTopic = false;
        }
        for (int i = 0; i <= 3; i++)
        {
            slider.value = 3 - i;
            yield return new WaitForSeconds(1);
        }

        canChangeTopic = true;
        foreach (GameObject btn in Buttons)
        {
            btn.GetComponent<TopicButtonClass>().canChangeTopic = true;
        }
        UpdateButtons();
    }
    public void UpdateByUser(string choice, float mood_upd, float er_upd, Sprite pic)
    {
        CurrentTheme.GetComponent<TMP_Text>().text=choice;
        
        SliderManager.GetComponent<SliderManager>().ChangeSliders(mood_upd, er_upd);
        PictureManager.GetComponent<PicturesManager>().UpdatePictures(pic);
        for (int i=0; i<3; i++)
        {
            GameObject btn = Buttons[i];
            btn.GetComponent<TMP_Text>().text = "wait!";
        }
        StartCoroutine(Cooldown());
        UpdateButtons();
        HeaderManager.GetComponent<HeaderManager>().UpdateHeaders(choice);
        NewsManager.GetComponent<NewsManager>().UpdateNews();
        
    }
    
    public void UpdateButtons()
    {
        if (!canChangeTopic)
            return;
        
        List<int> used = new List<int>();
        while (used.Count != 3)
        {
            int index = RandomGenerator.NextInt(0, 10);
            if (!(used.Contains(index)) && used.Count != 3)
            {
                used.Add(index);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject btn = Buttons[i];
            string topic_name = topics[used[i]];
            Sprite icon = picturesList[used[i]];
            float mood_update = mood_updates[used[i]];
            float engagement_update = er_update[used[i]];
            btn.GetComponent<TopicButtonClass>().DataUpdate(new TopicClass(topic_name, icon, mood_update, engagement_update));
            btn.GetComponent<TMP_Text>().text = btn.GetComponent<TopicButtonClass>().ToString();
        }
    }

    public IEnumerator FreezeButtons(float time)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject btn = Buttons[i];
            btn.GetComponent<TMP_Text>().text = "wait!";
            
            btn.GetComponent<TopicButtonClass>().canChangeTopic = false;
        }

        canChangeTopic = false;

        yield return new WaitForSeconds(time);

        canChangeTopic = true;
        foreach (GameObject btn in Buttons)
        {
            btn.GetComponent<TopicButtonClass>().canChangeTopic = true;
        }

        UpdateButtons();
    }

    void Update()
    {

    }
}
