using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera c;
    void Start()
    {
        GameObject g = GameObject.Find("Camera");

        if (g == null) { c = Camera.main; } else { c = g.GetComponent<Camera>();  }
    }

    void Update()
    {
        transform.forward = c.transform.forward;
    }
}
