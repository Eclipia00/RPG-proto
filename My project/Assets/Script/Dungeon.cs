using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data
{
    public string enemyType;
    public float enemyX;
    public float enemyY;
    public float enemyZ;
}

public class Portal_Data
{
    public float portalX;
    public float portalY;
    public float portalZ;
}

public class Dungeon : MonoBehaviour
{
    public string stageName;
    public int enemyNum;
    public Enemy_Data[] enemyData;
    public bool portal;
    public Portal_Data portalData;
}