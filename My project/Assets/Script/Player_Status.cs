using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : Status
{
    public Equipment weapon;

    // Start is called before the first frame update
    void Start()
    {
        HP = Level * 100;
        Physicsal_Attack = Level * 10 + weapon.Attack_Power;
        Magic_Attack = Level * 10 + weapon.Attack_Power;
        Critical = 0.10f;
        Critical_Damage = 0;
        Physical_Defense = (Level / 10) * 1;
        Magic_Defense = (Level / 10) * 1;
        Physical_Defense_Ignore = (Level / 10) * 2;
        Magic_Defense_Ignore = (Level / 10) * 2;
        Attack_Speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HP = Level * 100;
        Physicsal_Attack = Level * 10 + weapon.Attack_Power;
        Magic_Attack = Level * 10 + weapon.Attack_Power;
        Critical = 0.10f;
        Critical_Damage = 0;
        Physical_Defense = (Level / 10) * 1;
        Magic_Defense = (Level / 10) * 1;
        Physical_Defense_Ignore = (Level / 10) * 2;
        Magic_Defense_Ignore = (Level / 10) * 2;
        Attack_Speed = 1;
    }
}