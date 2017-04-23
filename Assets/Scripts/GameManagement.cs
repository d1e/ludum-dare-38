using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    AsyncOperation async1;
    AsyncOperation async2;
    // Use this for initialization
    void Start () 
	{
        //PlayerPrefs.SetFloat("WorldRotation", transform.parent.rotation.x);
        async1 = SceneManager.LoadSceneAsync("main", LoadSceneMode.Additive);
        async2 = SceneManager.LoadSceneAsync("ui", LoadSceneMode.Additive);

        StartCoroutine(iSync());
    }

    public IEnumerator iSync()
    {
        while (!async1.isDone)
        {
            print("true");
            yield return new WaitForSeconds(0.2f);
        }
        while (!async2.isDone)
        {
            print("true");
            yield return new WaitForSeconds(0.2f);
        }

        GameObject g = GameObject.Find("Main Camera");
        g.SetActive(false);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
