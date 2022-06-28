using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] Rigidbody rigid
    
    CharacterBehavior characterBehavior;
    // Start is called before the first frame update
    
    void Start()
    {
        characterBehavior = gameObject.GetComponent<CharacterBehavior>();
        Joystick();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        //
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
}
