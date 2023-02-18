using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float max_HP;
    public float now_HP;
    public GameObject unit;
    Status enemy_status;

    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damaged,
        Die
    }

    public EnemyState enemySate;
    Transform player;
    CharacterController cc;

    public float findDistance = 5f;
    public float attackDistance = 1f;
    public float moveSpeed = 0.1f;
    float currentTime = 0;
    public float attackDelay = 2f;


    // Start is called before the first frame update
    void Start()
    {
        enemySate = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        enemy_status = gameObject.GetComponent<Status>();
        max_HP = enemy_status.HP;
        now_HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemySate)
        {
            case EnemyState.Idle: Idle(); break;
            case EnemyState.Move: Move(); break;
            case EnemyState.Attack: Attack(); break;
            case EnemyState.Damaged: Damaged(); break;
            case EnemyState.Die: Die();  break;
        }
    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) <  findDistance) 
        {
            enemySate = EnemyState.Move;
            Debug.Log("Idle -> Move");
        }
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else
        {
            enemySate = EnemyState.Attack;
            Debug.Log("Move -> Attack");
        }
    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                Debug.Log("Attack!!");
                currentTime = 0;
            }
        }
        else
        {
            enemySate = EnemyState.Move;
            Debug.Log("Attack -> Move");
            currentTime = 0;
        }
    }

    void Damaged()
    {
        
    }
    public void Diminish_enemy_HP(float damage)
    {
        now_HP = now_HP - damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
