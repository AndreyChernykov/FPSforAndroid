using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool gunIsCharged = true;//заряжен ли ствол
    private int numberOfBullet = 2;//количество заряжаемых патронов
    private int bulletOfShoot = 0;//количество выстрелов до перезарядки
    [SerializeField] int bullet = 10;//патронов в запасе

    public void Shoot()//выстрелы
    {
       
        if (gunIsCharged)
        {                     
            bulletOfShoot++;
            Debug.Log(bulletOfShoot + " bang!");
            gunIsCharged = bulletOfShoot >= numberOfBullet ? false : true;

        }

    }

    public void ChargedGun()//перезарядка
    {
        
        if (!gunIsCharged && bullet > 0)
        {
            bulletOfShoot = 0;
            bullet -= numberOfBullet;
            gunIsCharged = true;
        }
               
    }

    public int Bullet
    {
        get { return bullet; }
    }
}
