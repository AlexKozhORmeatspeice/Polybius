using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LoadingScriptText : MonoBehaviour
{
    [SerializeField] private GameObject text;

    void Start()
    {
        StartCoroutine(AnimateText());
        StartCoroutine(LoadScene());
    }

    private IEnumerator AnimateText()
    {
        for (int i = 0; i<10; i++)
        {
            string newText = "Loading.";
            for (int j = 0; j<(i%3); j++)
            {
                newText += ".";
            }
            text.GetComponent<TMP_Text>().text = newText;
            yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(4.7f);
        SceneManager.LoadScene(CrossSceneInfo.nextScene);
    }
}
