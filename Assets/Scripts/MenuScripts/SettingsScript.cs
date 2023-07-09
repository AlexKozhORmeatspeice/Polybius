using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private Button settingsButton;
    void Start()
    {
        settingsButton = GetComponent<Button>();
        settingsButton.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        CrossSceneInfo.nextScene = 2;
        SceneManager.LoadScene("Loading");
    }
    
}
