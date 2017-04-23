using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    AsyncOperation async;
	// Use this for initialization
	void Start () 
	{
        //PlayerPrefs.SetFloat("WorldRotation", transform.parent.rotation.x);
        async = SceneManager.LoadSceneAsync("main", LoadSceneMode.Additive);
        StartCoroutine(iSync());
    }

    public IEnumerator iSync()
    {
        while (!async.isDone)
        {
            print("true");
            yield return new WaitForSeconds(0.5f);
        }
        
        GameObject g = GameObject.Find("Main Camera");
        g.SetActive(false);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
