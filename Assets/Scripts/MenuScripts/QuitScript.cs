using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitScript : MonoBehaviour
{
    private Button quitButton;
    void Start()
    {
        quitButton=GetComponent<Button>();
        quitButton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        StartCoroutine(QuitGame());
    }
    
    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(0.1f);
        Application.Quit();
    }
}
