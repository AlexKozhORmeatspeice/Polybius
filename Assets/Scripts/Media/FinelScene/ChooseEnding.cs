using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChooseEnding : MonoBehaviour
{
    private VideoPlayer _player;
    
    [SerializeField] private VideoClip goodEnding;
    [SerializeField] private VideoClip badEnding;
    // Start is called before the first frame update

    public void ChooseEnd()
    {
        Slider slider = SliderManager.instance.mood_slider.GetComponent<Slider>();
        
        if (slider.value <= 0.3f * slider.maxValue)
        {
            _player.clip = badEnding;
        }
        else
        {
            _player.clip = goodEnding;
        }
    }
}
