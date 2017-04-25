using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickShards : MonoBehaviour
{
   

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boy")
        {
            this.enabled = false;
            GameManagement gm = GameObject.Find("game manager").GetComponent<GameManagement>();
            StartCoroutine(gm.iSyncLevelOut("boylevelone"));
        }
    }
}
