using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject[] typOfBullet;
    [SerializeField] GameObject hendsAndGun;
    [SerializeField] GameObject barrelEnd;//откуда вылетает пуля
    [SerializeField] AudioClip charged;
    [SerializeField] AudioClip misfire;


    private bool gunIsCharged = false;//заряжен ли ствол
    private int numberOfBullet = 2;//количество заряжаемых патронов
    private int bulletOfShoot = 0;//количество выстрелов до перезарядки
    Inventary inventary;
    Animator animator;

    AudioSource audioSource;
    private int amountBullets;
    
    GameObject bulletPref;

    void Start()
    {
        inventary = new Inventary();
        animator = hendsAndGun.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        bulletPref = typOfBullet[2];//заряжаем пушку перед началом игры
        gunIsCharged = true;
    }

    public void Shoot()//выстрелы
    {
        audioSource.PlayOneShot(misfire);
        if (gunIsCharged)
        {          
            bulletOfShoot++;
            Debug.Log(bulletOfShoot + " bang!");
            gunIsCharged = bulletOfShoot >= numberOfBullet ? false : true;
            amountBullets = bulletPref.GetComponent<Bullet>().AmountBullets;
            while(amountBullets > 0)
            {
                animator.SetBool("Shooting", true);
                
                audioSource.Play();
                GameObject bl = Instantiate(bulletPref);

                bl.transform.SetParent(gameObject.transform);
                bl.transform.localPosition = barrelEnd.transform.localPosition;

                bl.transform.rotation = transform.rotation;
                bl.transform.parent = null;

                amountBullets--;

                Invoke("AnimShootEnd", 1f);

            }


        }

    }

    void AnimShootEnd()//конец анимации выстрела
    {
        animator.SetBool("Shooting", false);
    }

    void ChargedGun()//перезарядка
    {
        animator.SetBool("Charge", true);
        bulletOfShoot = 0;
        audioSource.PlayOneShot(charged);
        
        Invoke("AnimChargeEnd", 2.5f);
    }

    void AnimChargeEnd()//конец анимации перезарядки
    {
        gunIsCharged = true;
        animator.SetBool("Charge", false);
    }

    public void ChargedBullet()//зарядка пулями
    {
        if (!animator.GetBool("Charge") && inventary.Bullet > 0)
        {
            inventary.SubBullet(numberOfBullet);
            bulletPref = typOfBullet[0];
            ChargedGun();
        }
        
    }

    public void ChargedShot()//зарядка дробью
    {
        if (!animator.GetBool("Charge") && inventary.Shot > 0)
        {
            inventary.SubShot(numberOfBullet);
            bulletPref = typOfBullet[1];
            ChargedGun();
        }
        
    }

    public void ChargedDummy()//зарядка холостыми
    {
        if (!animator.GetBool("Charge") && inventary.Dummy > 0)
        {
            inventary.SubDummy(numberOfBullet);
            bulletPref = typOfBullet[2];
            ChargedGun();
        }
        
    }
}
