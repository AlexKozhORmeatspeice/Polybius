using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    [SerializeField] private GameObject FirstNews;
    [SerializeField] private GameObject SecondNews;
    [SerializeField] private GameObject ThirdNews;

    private List<GameObject> News = new List<GameObject>();

    private Unity.Mathematics.Random RandomGenerator = new Unity.Mathematics.Random(123);
    private string LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod 
tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco
laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse 
cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt 
ut Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure 
dolor in reprehenderit in voluptate velit esse  cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat
non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur
adipisicing elit, sed do eiusmod tempor incididunt ut ";
    void Start()
    {
        News.Add(FirstNews);
        News.Add(SecondNews);
        News.Add(ThirdNews);
        
    }

    public void UpdateNews()
    {
        int begin = RandomGenerator.NextInt(0, 240);
        string move_string = LoremIpsum.Substring(begin, begin + 540);
        for (int i = 0; i<3; i++)
        {
            string temp = News[i].GetComponent<TMP_Text>().text;
            News[i].GetComponent<TMP_Text>().text = move_string;
            move_string = temp;
        }
    }
}
