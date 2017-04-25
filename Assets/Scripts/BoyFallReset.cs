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
            float startX = PlayerPrefs.GetFloat("BoyStartingPosX", transform.position.x);
            float startY = PlayerPrefs.GetFloat("BoyStartingPosY", transform.position.y);
            float startZ = PlayerPrefs.GetFloat("BoyStartingPosZ", transform.position.z);
           
            boy.transform.position = new Vector3(
                startX, startY, startZ
            );
        }
    }
}
