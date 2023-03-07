using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().enemy_count <= 0)
        {
            gameObject.GetComponentInChildren<Renderer>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        Debug.Log("Collision");

        if (GameObject.Find("GameManager").GetComponent<GameManager>().enemy_count <= 0)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
