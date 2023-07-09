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
        CrossSceneInfo.nextScene = "Settings";
        StartCoroutine(LoadScene());
    }
    
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Loading");
    }
}
