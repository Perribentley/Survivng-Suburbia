using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string NewGameScene;
    public string CreditsScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }

    public void CreditPage()
    {
        SceneManager.LoadScene(CreditsScene);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
