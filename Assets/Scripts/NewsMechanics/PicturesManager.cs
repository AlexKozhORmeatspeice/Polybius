using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicturesManager : MonoBehaviour
{
    [SerializeField] private GameObject FirstPlace;
    [SerializeField] private GameObject SecondPlace;
    [SerializeField] private GameObject ThirdPlace;


    private List<GameObject> places = new List<GameObject>();
    private List<Texture2D> pictures = new List<Texture2D>();
    
    void Start()
    {
        places.Add(FirstPlace);
        places.Add(SecondPlace);
        places.Add(ThirdPlace);
    }
    
    public void UpdatePictures(Sprite picture)
    {
        for (int i = 0; i<3; i++)
        {
            Sprite temp = places[i].GetComponent<Image>().sprite;
            places[i].GetComponent<Image>().sprite = picture;
            picture = temp;
        }
    }

    
}
