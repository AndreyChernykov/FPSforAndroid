using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    
    [SerializeField] GameObject[] uIElements;
    [SerializeField] GameObject panelNewGame;
    [SerializeField] GameObject panelOptions;
    bool isVisPanelNewGame = false;
    bool isVisPanelOptions = false;
    void Start()
    {
        
    }

    public void ClickBtnPlayNew()//здесь будет сброс прогресса и начало игры сначала)
    {
        SceneManager.LoadScene("District01");
    }

    public void UIElementActivs(bool b)//прячем-активируем элементы меню
    {
        foreach(var i in uIElements)
        {
            i.SetActive(b);
        }

    }

    public void ClickBtnNewGame()//при нажатии на кнопку новой игры
    {
        if (!isVisPanelNewGame)
        {
            UIElementActivs(false);
            panelNewGame.SetActive(true);
            isVisPanelNewGame = true;            
        }
        else
        {
            UIElementActivs(true);
            panelNewGame.SetActive(false);
            isVisPanelNewGame = false;
        }
    }

    public void ClickOptions()//при нажатии кнопки опций
    {
        if (!isVisPanelOptions)
        {
            UIElementActivs(false);
            panelOptions.SetActive(true);
            isVisPanelOptions = true;
        }
        else
        {
            UIElementActivs(true);
            panelOptions.SetActive(false);
            isVisPanelOptions = false;
        }
    }

    public void ClickExit()//Выход из игры
    {
        Application.Quit();
    }
}
