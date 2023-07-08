using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FirstHeader;
    [SerializeField]
    private GameObject SecondHeader;
    [SerializeField]
    private GameObject ThirdHeader;

    List<GameObject> Headers = new List<GameObject>();
    void Start()
    {
        Headers.Add(FirstHeader);
        Headers.Add(SecondHeader);
        Headers.Add(ThirdHeader);
    }

    public void UpdateHeaders(string header)
    {
        for (int i=0;i<3;i++)
        {
            string temp = Headers[i].GetComponent<TMP_Text>().text;
            Headers[i].GetComponent<TMP_Text>().text = header;
            header = temp;
        }
    }
}
