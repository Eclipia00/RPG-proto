using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject nextEnemy = GameObject.Find("S2_Enemy");
        if (GameObject.Find("GameManager").GetComponent<GameManager>().enemy_count <= 0)
        {
            nextEnemy.GetComponent<S2_Enemy>().spawn();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        GameObject nextEnemy = GameObject.Find("S2_Enemy");
        Debug.Log("Collision2");

        if (GameObject.Find("GameManager").GetComponent<GameManager>().enemy_count <= 0)
        {
            nextEnemy.GetComponent<S2_Enemy>().spawn();
            Destroy(this.gameObject);
        }
    }
}
