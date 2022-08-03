using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject[] typOfBullet;
    [SerializeField] Vector3 barrelEnd;//откуда вылетает пуля
    [SerializeField] AudioClip charged;
    [SerializeField] AudioClip misfire;
    private bool gunIsCharged = false;//заряжен ли ствол
    private int numberOfBullet = 2;//количество заряжаемых патронов
    private int bulletOfShoot = 0;//количество выстрелов до перезарядки
    Inventary inventary;
    Animator animator;

    Animation animationShoot;
    AudioSource audioSource;
    private int amountBullets;
    
    GameObject bulletPref;

    void Start()
    {
        inventary = new Inventary();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                bl.transform.localPosition = barrelEnd;

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
        bulletOfShoot = 0;
        audioSource.PlayOneShot(charged);
        gunIsCharged = true;

    }

    public void ChargedBullet()//зарядка пулями
    {
        if (!gunIsCharged && inventary.Bullet > 0)
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
