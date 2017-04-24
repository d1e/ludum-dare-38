using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyFallReset : MonoBehaviour
{

    public string platformName;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D boy)
    {
        Debug.Log("fell");
        if (boy.tag == "boy")
        {
            GameObject resetTo = GameObject.Find(platformName);
            Debug.Log(resetTo);
            boy.transform.position = new Vector3(
                resetTo.transform.position.x - 5, 
                resetTo.transform.position.y + 5,
                boy.transform.position.z
            );
        }
    }
}
