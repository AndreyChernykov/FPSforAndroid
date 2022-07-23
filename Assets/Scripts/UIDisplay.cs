using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBullet;
    [SerializeField] TextMeshProUGUI textHealth;
    [SerializeField] TextMeshProUGUI textTimer;
    Inventary inventary;
    private void Start()
    {
        inventary = new Inventary();
        MainController.actionList.Add(DisplayNumberOfBullet);
        MainController.actionList.Add(DisplayHealth);
        MainController.actionList.Add(DisplayTimer);
    }

    public void DisplayTimer()//отображение времени игры 
    {      
        textTimer.text = "Time: " + inventary.Time;
    }

    public void DisplayHealth()//отоброжение количества здоровья
    {
        textHealth.text = "HEALTH: " + inventary.Health;
    }

    public void DisplayNumberOfBullet()//отоброжение количества патронов
    {
        
        textBullet.text = inventary.ToString();


    }
}
