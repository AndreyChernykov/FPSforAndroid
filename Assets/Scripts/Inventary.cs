using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary
{
    const int HEALTH = 100;
    const int TIME = 100;
    const int BULLET = 10;
    const int SHOT_BULET = 10;
    const int DUMMY_BULLET = 10;

    static int health;//здоровье героя
    static int time;//время на игру
    static int timeRecovery = 2;//время восстановления единицы здоровья
    static int dummyBullet;//холостые патроны
    static int bullet;//обычные патроны
    static int shotBullet;//дробь

    public Inventary()
    {
        health = HEALTH;
        time = TIME;
        dummyBullet = DUMMY_BULLET;
        bullet = BULLET;
        shotBullet = SHOT_BULET;
    }

    public int Health
    {
        get { return health; }
    }

    public int Time
    { 
        get { return time; }
        set { time--; }
    }

    public int TimeRecovery
    {
        get { return timeRecovery; }
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
        if (health > 0 && health < HEALTH)
        {
            health++;
        }
    }

    public int Bullet
    {
        get { return bullet; }
    }

    public int Shot
    {
        get { return shotBullet; }
    }

    public int Dummy
    {
        get { return dummyBullet; }
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
