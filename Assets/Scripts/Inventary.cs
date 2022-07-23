using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary
{
    static int health = 10;//здоровье героя
    const int maxHealth = 10;
    static int time = 1000;//время на игру
    static int dummyBullet = 10;//холостые патроны
    static int bullet = 10;//обычные патроны
    static int shotBullet = 10;//дробь

    public int Health
    {
        get { return health; }
    }

    public int Time
    { 
        get { return time; }
        set { time--; }
    }



    public void HealthFault(int d)//повреждение здоровья
    {
        if (health >= 0)
        {
            health-=d;
        }
    }

    public void HealthRecovery()//восстановление здоровья
    {
        if (health > 0 && health < maxHealth)
        {
            health++;
        }
    }

    public int Bullet
    {
        get { return bullet; }
    }
    public void AddBullet(int n)
    {
        bullet += n;
    }

    public void SubBullet(int n)
    {
        if(bullet > 0)bullet-=n;
    }

    public void AddDummy(int n)
    {
        dummyBullet += n;
    }

    public void SubDummy(int n)
    {
        if(dummyBullet > 0)dummyBullet -= n;
    }

    public void AddShot(int n)
    {
        shotBullet += n;
    }

    public void SubShot(int n)
    {
        if(shotBullet > 0)shotBullet -= n;
    }

    public override string ToString()
    {
        
        return "Dummy Bullet: " + dummyBullet + "\nBullet: " + bullet + "\nShot Bullet: " + shotBullet;
    }
}
