using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : Status
{
    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        HP = Level * 100;
        Physicsal_Attack = Level;
        Magic_Attack = Level;
        Critical = 0.1f;
        Critical_Damage = Level / 10;
        Physical_Defense = (Level / 10) * 2;
        Magic_Defense = (Level / 10) * 2;
        Physical_Defense_Ignore = 0;
        Magic_Defense_Ignore = 0;
        Attack_Speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
