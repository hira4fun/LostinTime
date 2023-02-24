using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject background;
    public int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }
        SceneManager.LoadScene("Level");
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        background.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        background.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
        background.SetActive(false);
    }

    public void CloseCredits()
    {  
        creditsScreen.SetActive(false);
        background.SetActive(true);
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
