using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBullet;
    Gun gun;
    private void Start()
    {
        MainController.actionList.Add(DisplayNumberOfBullet);
        GameObject gunObj = GameObject.Find("Gun");

        if(gunObj != null) gun = gunObj.GetComponent<Gun>();
    }

    public void DisplayNumberOfBullet()//отоброжение количества патронов
    {
        if(gun != null)
        {
            textBullet.text = "Bullet: " + gun.Bullet;
        }
        
    }
}
