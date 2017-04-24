using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {

    public int level;
	
    // Use this for initialization
	public void button () {
        SceneManager.LoadScene(level);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
