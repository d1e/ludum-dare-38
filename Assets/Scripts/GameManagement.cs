using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    AsyncOperation async1;
    AsyncOperation async2;
    AsyncOperation async3;
    // Use this for initialization
    void Start () 
	{
        BeginGame();
    }

    public void LoadMenu()
    {
        async1 = SceneManager.LoadSceneAsync("titlemenu", LoadSceneMode.Additive);
    }

    public void BeginGame()
    {
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

    public IEnumerator iSyncLevelIn(string levelName)
    {
        Vector3 v = FindLevelGate(levelName).GetComponent<EnterLevel>().zoomDisplace;
        float z = FindLevelGate(levelName).GetComponent<EnterLevel>().zoomSize;

        GameObject g = GameObject.Find("Camera");

        async3 = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        while (!async3.isDone)
        {
            print("true");
            yield return new WaitForSeconds(0.2f);
        }

        FindLevelObject(levelName).transform.position = v;
        Camera cam = g.GetComponent<Camera>();
        while (cam.fieldOfView > z + 0.05f || cam.fieldOfView < z - 1f)
        {
            if (cam.fieldOfView > z)
            {
                cam.fieldOfView = cam.fieldOfView - 1f;
            }
            else if (cam.fieldOfView < z)
            {
                cam.fieldOfView = cam.fieldOfView + 1f;
            }



            yield return new WaitForSeconds(0.1f);
        }

    }

    public GameObject FindLevelGate(string levelName)
    {
        return GameObject.Find("level-gate"); //levelName
    }

    public GameObject FindLevelObject(string objectName)
    {
        return GameObject.Find(objectName); //levelName
    }



    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(iSyncLevelIn("boylevelone"));
        }

	}
}
