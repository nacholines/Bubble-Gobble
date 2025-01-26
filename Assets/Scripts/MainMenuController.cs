using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;

    private void Awake()
    {
        CloseCredits();
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
