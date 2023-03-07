using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject prefab;
    GameObject stage;
    GameObject player;
    Vector3 start = new Vector3(0, 0, 0);
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefab/1-1");
        stage = Instantiate(prefab);
        player.transform.position = start;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
