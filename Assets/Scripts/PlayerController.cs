using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ClickBtnCharged()
    {
        MainController.actionList.Add(gun.ChargedGun);
    }

    public void UnClickBtnCharged()
    {
        MainController.actionList.Remove(gun.ChargedGun);
    }
}
