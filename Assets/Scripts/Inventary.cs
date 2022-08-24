using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary
{
    const int HEALTH = 100;
    const int TIME = 500;
    const int TIME_RECOVERY = 2;//время восстановления единицы здоровья
    const int BULLET = 10;
    const int SHOT_BULET = 0;
    const int DUMMY_BULLET = 10;
    const int ALL_BOOK_LEAFS = 10;//всего итемов собираемых листков книги в игре

    static int health;//здоровье героя
    static int time;//время на игру
    
    static int dummyBullet;//холостые патроны
    static int bullet;//обычные патроны
    static int shotBullet;//дробь
    static int bookLeafs;//собрано листов из книги
    static int killsZombies;//количество убитых зоби

    public void StartGame()
    {
        health = HEALTH;
        time = TIME;
        dummyBullet = DUMMY_BULLET;
        bullet = BULLET;
        shotBullet = SHOT_BULET;
        bookLeafs = 0;
        killsZombies = 0;
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
        get { return TIME_RECOVERY; }
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

    public int BookLeaf
    {
        get { return bookLeafs; }
        set { bookLeafs += value; }
    }

    public int AllBookLeafs
    {
        get { return ALL_BOOK_LEAFS; }
    }

    public int KillsZombies
    {
        get { return killsZombies; }
        set { killsZombies += value; }
    }

    public override string ToString()
    {
        
        return "Dummy Bullet: " + dummyBullet + "\nBullet: " + bullet + "\nShot Bullet: " + shotBullet;
    }
}
