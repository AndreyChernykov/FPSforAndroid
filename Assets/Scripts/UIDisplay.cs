using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBullet;
    [SerializeField] TextMeshProUGUI textShot;
    [SerializeField] TextMeshProUGUI textDummy;
    [SerializeField] TextMeshProUGUI textHealth;
    [SerializeField] TextMeshProUGUI textTimer;
    [SerializeField] TextMeshProUGUI textBookLeafs;
    Inventary inventary;
    private void Start()
    {
        inventary = new Inventary();
        MainController.actionList.Add(DisplayNumberOfBullet);
        MainController.actionList.Add(DisplayNumberOfShot);
        MainController.actionList.Add(DisplayNumberOfDummy);
        MainController.actionList.Add(DisplayHealth);
        MainController.actionList.Add(DisplayTimer);
        MainController.actionList.Add(DisplayBookLeafs);
    }

    public void DisplayTimer()//отображение времени игры 
    {      
        textTimer.text = "Time: " + inventary.Time;
    }

    public void DisplayHealth()//отоброжение количества здоровья
    {
        textHealth.text = "HEALTH: " + inventary.Health;
    }

    public void DisplayNumberOfBullet()//отоброжение количества патронов с пулями
    {        
        textBullet.text = inventary.Bullet.ToString();
    }

    public void DisplayNumberOfShot()//отоброжение количества патронов с дробью
    {
        textShot.text = inventary.Shot.ToString();
    }

    public void DisplayNumberOfDummy()//отоброжение количества патронов холостых
    {
        textDummy.text = inventary.Dummy.ToString();
    }

    public void DisplayBookLeafs()//отображение собраных листков из книги
    {
        textBookLeafs.text = "Book leafs: " + inventary.BookLeaf + "/" + inventary.AllBookLeafs;
    }
}
