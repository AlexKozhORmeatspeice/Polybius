using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{
    
    private Button playButton;
    
    
    void Start()
    {
        playButton=GetComponent<Button>();
        playButton.onClick.AddListener(ChangeScene);
    }

   private void ChangeScene()
    {
        CrossSceneInfo.currentMood = 15;
        CrossSceneInfo.nextScene = "Morning";
        StartCoroutine(LoadScene());
    }
    
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Loading");
    }
}
