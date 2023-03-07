using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public float Attack_Power;
    float critical;
    Player_Status player_status;
    Status obstacle_status;
    Status enemy_status;
    GameObject target;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player_status = gameObject.GetComponent<Player_Status>();
        obstacle_status = GameObject.Find("Obstacle").GetComponent<Status>();
        enemy_status = GameObject.Find("Enemy").GetComponent<Enemy_Status>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        //기본공격
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Attack");
            RaycastHit target_ray;
            if(Physics.Raycast(this.transform.position, this.transform.forward, out target_ray, 10.0f))
            {
                Debug.Log(target_ray.transform.name);
                if(target_ray.transform.tag == "Enemy")
                {
                    Attack(target_ray.transform.gameObject);
                }
            }
        }



        // 범위공격
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Attack");
            Collider[] colls = Physics.OverlapSphere(transform.position, 100.0f);
            for (int i = 0; i < colls.Length; i++)
            {
                if(colls[i].gameObject.tag == "Enemy")
                {
                    Attack(colls[i].transform.gameObject);
                }
            }
        }
    }

    void Attack(GameObject target)
    {
        float critical = Random.Range(0.0f, 1.0f);
        float attackPower = 0;

        if (critical < player_status.Critical)
        {
            Debug.Log("크리티컬!");
            if (player_status.Physical_Defense_Ignore > enemy_status.Physical_Defense)
            {
                attackPower = player_status.Physicsal_Attack + player_status.Critical_Damage;
            }
            else
            {
                attackPower = 1;
                Debug.Log("Block!");
            }
        }
        else
        {
            if (player_status.Physical_Defense_Ignore > enemy_status.Physical_Defense)
            {
                attackPower = player_status.Physicsal_Attack;
            }
            else
            {
                attackPower = 0;
                Debug.Log("Block!");
            }
        }
        target.gameObject.GetComponent<Enemy>().Diminish_enemy_HP(attackPower);
        if (target.gameObject.GetComponent<Enemy>().now_HP > 0)
        {
            target.gameObject.GetComponent<Enemy>().enemySate = Enemy.EnemyState.Damaged;
        }
        else
        {
            target.gameObject.GetComponent<Enemy>().enemySate = Enemy.EnemyState.Die;
        }
    }

    void OnCollisionEnter(Collision other) // 장애물 파괴
    {
        if (other.gameObject.name == "Obstacle")
        {
            critical = Random.Range(0.0f, 1.0f);
            if (critical < player_status.Critical)
            {
                Debug.Log("크리티컬!");
                if (player_status.Physical_Defense_Ignore > obstacle_status.Physical_Defense)
                {
                    Attack_Power = player_status.Physicsal_Attack + player_status.Critical_Damage;
                }
                else
                {
                    Attack_Power = 1;
                    Debug.Log("Block!");
                }
                other.gameObject.GetComponent<Obstacle>().Diminish_HP(Attack_Power);
            }
            else
            {
                if (player_status.Physical_Defense_Ignore > obstacle_status.Physical_Defense)
                {
                    Attack_Power = player_status.Physicsal_Attack;
                } 
                else
                {
                    Attack_Power = 0;
                    Debug.Log("Block!");
                }
                other.gameObject.GetComponent<Obstacle>().Diminish_HP(Attack_Power);
            }
        }
    }
}