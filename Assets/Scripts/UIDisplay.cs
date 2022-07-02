using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBullet;
    Inventary inventary;
    private void Start()
    {
        inventary = new Inventary();
        MainController.actionList.Add(DisplayNumberOfBullet);
              
    }

    public void DisplayNumberOfBullet()//отоброжение количества патронов
    {
        
        textBullet.text = inventary.ToString();


    }
}
