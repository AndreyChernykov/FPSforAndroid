using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] Rigidbody rigid
    
    CharacterBehavior characterBehavior;
    Gun gun;
    
    
    void Start()
    {
        characterBehavior = gameObject.GetComponent<CharacterBehavior>();
        gun = gameObject.GetComponentInChildren<Gun>();
        Joystick();
    }



    public void ClickBtnMove()
    {
        MainController.actionList.Add(characterBehavior.Move);
    }

    public void UnClickBtnMove()
    {
        MainController.actionList.Remove(characterBehavior.Move);
    }

    public void Joystick()
    {
        MainController.actionList.Add(characterBehavior.Turn);
        MainController.actionList.Add(characterBehavior.VertVisibl);
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
        }
    }
}
