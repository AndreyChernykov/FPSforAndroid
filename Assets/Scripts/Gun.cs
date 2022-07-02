using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool gunIsCharged = false;//заряжен ли ствол
    private int numberOfBullet = 2;//количество заряжаемых патронов
    private int bulletOfShoot = 0;//количество выстрелов до перезарядки
    Inventary inventary;
    private int amountBullets;
    [SerializeField] GameObject[] typOfBullet;
    GameObject bulletPref;

    void Start()
    {
        inventary = new Inventary();
    }

    public void Shoot()//выстрелы
    {
       
        if (gunIsCharged)
        {
            
            bulletOfShoot++;
            Debug.Log(bulletOfShoot + " bang!");
            gunIsCharged = bulletOfShoot >= numberOfBullet ? false : true;
            amountBullets = bulletPref.GetComponent<Bullet>().amountBullets;
            while(amountBullets > 0)
            {
                GameObject bl = Instantiate(bulletPref);

                bl.transform.SetParent(gameObject.transform);
                bl.transform.localPosition = new Vector3(0, -0.22f, 2);

                bl.transform.rotation = transform.rotation;
                bl.transform.parent = null;

                amountBullets--;
            }


        }

    }

    void ChargedGun()//перезарядка
    {
        bulletOfShoot = 0;
        gunIsCharged = true;

    }

    public void ChargedBullet()//зарядка пулями
    {
        if (!gunIsCharged)
        {
            inventary.SubBullet(numberOfBullet);
            bulletPref = typOfBullet[0];
            ChargedGun();
        }
        
    }

    public void ChargedShot()//зарядка дробью
    {
        if (!gunIsCharged)
        {
            inventary.SubShot(numberOfBullet);
            bulletPref = typOfBullet[1];
            ChargedGun();
        }
        
    }

    public void ChargedDummy()//зарядка холостыми
    {
        if (!gunIsCharged)
        {
            inventary.SubDummy(numberOfBullet);
            bulletPref = typOfBullet[2];
            ChargedGun();
        }
        
    }
}
