using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public OyunKontrol oyunK;

    void Update()
    {
        if (!oyunK.oyunAktif)
        {
            SceneManager.LoadScene("Ölüm Ekranı");
        }
    }
    
}
