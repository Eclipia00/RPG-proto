using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        foreach (Transform child in this.transform)
        {
            Debug.Log(child.name);
            child.gameObject.SetActive(true);
        }
    }
}
