using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyPrefs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetFloat("BoyStartingPosX", transform.position.x);
        PlayerPrefs.SetFloat("BoyStartingPosY", transform.position.y);
        PlayerPrefs.SetFloat("BoyStartingPosZ", transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
