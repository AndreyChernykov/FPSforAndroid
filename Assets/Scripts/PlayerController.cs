using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] GameObject panelChange;
    [SerializeField] GameObject panelPauseMenu;
    [SerializeField] GameObject panelGameOver;
    [SerializeField] FixedJoystick joystickMove;
    [SerializeField] FixedJoystick joystickTurn;
    [SerializeField] GameObject[] btnActivate;

    CharacterBehavior characterBehavior;
    Gun gun;
    bool panelChangeIsVisible = false;
    bool isPause = false;
    
    void Start()
    {
        Time.timeScale = 1;
        characterBehavior = gameObject.GetComponent<CharacterBehavior>();
        gun = gameObject.GetComponentInChildren<Gun>();
        JoystickTurn();
        JoystickMove();
    }

    public float JoystyckMoveHorizontal
    {
        get { return joystickMove.Horizontal; }
    }

    public float JoystyckMoveVertical
    {
        get { return joystickMove.Vertical; }
    }

    public float JoystickTurnHorizontal
    {
        get { return joystickTurn.Horizontal; }
    }

    public float JoysticTurnVertical
    {
        get { return joystickTurn.Vertical; }
    }

    public void ClickPauseMenu()//пауза
    {
        int t;
        if (!isPause)
        {
            t = 0;
            panelPauseMenu.SetActive(true);
            isPause = true;
        }
        else
        {
            t = 1;
            panelPauseMenu.SetActive(false);
            isPause = false;
        }
        Time.timeScale = t;
    }

    public void ClickExitToMainMenu()//при нажатии выхода в главное меню
    {
        MainController.actionList.Clear();
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ClickAmmoChange()//вызов панели с выбором боеприпасов
    {
        if(!panelChangeIsVisible)
        {
            panelChange.SetActive(true);
            foreach(var btn in btnActivate)
            {
                btn.SetActive(false);
            }
            panelChangeIsVisible = true;
        }
        else
        {
            panelChange.SetActive(false);
            foreach (var btn in btnActivate)
            {
                btn.SetActive(true);
            }
            panelChangeIsVisible = false;
        }

        
    }


    public void JoystickTurn()
    {
        MainController.actionList.Add(characterBehavior.Turn);
        MainController.actionList.Add(characterBehavior.VertVisibl);
    }

    public void JoystickMove()
    {
        MainController.actionList.Add(characterBehavior.Move);
    }

    public void ClickBtnShoot()
    {
        gun.Shoot();
        
    }

    public void UnClickBtnShoot()
    {
        //MainController.actionList.Remove(gun.Shoot);
    }

    public void ClickBtnCharged(Button btn)
    {
        
        if (gun != null)
        { 
            switch (btn.tag)
            {
                case "bullet":
                    MainController.actionList.Add(gun.ChargedBullet);
                    break;
                case "dummy":
                    MainController.actionList.Add(gun.ChargedDummy);
                    break;
                case "shot":
                    MainController.actionList.Add(gun.ChargedShot);
                    break;
            }
        }
        
    }

    public void UnClickBtnCharged()
    {
        if (gun != null)
        {
            MainController.actionList.Remove(gun.ChargedBullet);
            MainController.actionList.Remove(gun.ChargedShot);
            MainController.actionList.Remove(gun.ChargedDummy);

            ClickAmmoChange();
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }


}
