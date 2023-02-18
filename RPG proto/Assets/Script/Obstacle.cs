using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Max_HP;
    public float Now_HP;
    public GameObject Unit;
    Status obstacle_status;

    // Start is called before the first frame update
    void Start()
    {
        obstacle_status = gameObject.GetComponent<Status>();
        Max_HP = obstacle_status.HP;
        Now_HP = Max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Now_HP <= 0)
        {
            Destroy(gameObject);
        }
    }

     public void Diminish_HP(float Damage)
    {
        Now_HP = Now_HP - Damage;
    }
}
