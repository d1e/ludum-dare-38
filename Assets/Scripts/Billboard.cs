using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera c;
    void Start()
    {
        c = GameObject.Find("Camera").GetComponent<Camera>();
        if (c == null) c = Camera.main;
    }

    void Update()
    {
        transform.forward = c.transform.forward;
    }
}
