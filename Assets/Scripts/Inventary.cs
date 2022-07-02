﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary
{
    static int dummyBullet = 10;//холостые патроны
    static int bullet = 10;//обычные патроны
    static int shotBullet = 10;//дробь


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
