using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{
    [SerializeField] GameObject LoadManager;
    private Button playButton;
    
    
    void Start()
    {
        playButton=GetComponent<Button>();
        playButton.onClick.AddListener(ChangeScene);
    }

   private void ChangeScene()
    {
        CrossSceneInfo.nextScene = 1;
        SceneManager.LoadScene("Loading");
    }
    
}
