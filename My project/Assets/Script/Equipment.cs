using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public float Required_Level;
    public float Equipment_Level;
    public float Grade;
    public float Attack_Power;

    // Start is called before the first frame update
    void Start()
    {
        Attack_Power = (Required_Level * 100 + Equipment_Level * 150) * ((100 + Grade) / 100);
    }

    // Update is called once per frame
    void Update()
    {
        Attack_Power = (Required_Level * 100 + (Equipment_Level * 150)) * ((100 + Grade) / 100);
    }
}
