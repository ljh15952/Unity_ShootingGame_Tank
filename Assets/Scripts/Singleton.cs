using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{

    private static Singleton _instance = null;

    public static Singleton GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }


    public float Hero_Move_Speed;
    public float Next_Shot_Time;
    public float Next_Shot_Delay = .5f;
    public float ShotBulletAngle = 0;
    public int ShotBulletCount = 1;


}

