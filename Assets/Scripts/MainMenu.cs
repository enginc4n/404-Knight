using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip ClickFx;

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Çıkış");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void ClickSound()
    {
        myFx.PlayOneShot(ClickFx);
    }
    public void LoadSonSahne()
    {
        SceneManager.LoadScene("Son Sahne");
    }
    public void LoadCreditSahne()
    {
        SceneManager.LoadScene("Credits");
    }

}
