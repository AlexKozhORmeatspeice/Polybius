using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CrossSceneInfo.nextScene = "Menu";
            StartCoroutine(LoadScene());
        }
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Loading");
    }
}
