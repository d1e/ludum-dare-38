using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    AsyncOperation async1;
    AsyncOperation async2;
    AsyncOperation async3;
    // Use this for initialization

    public string nearestLevel = "none";
    public List<string> levelsCompleted = new List<string>();

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
        string levelCamName = levelName + "Cam";
        GameObject cam = GameObject.Find("Camera");

        async3 = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        while (!async3.isDone)
        {
            print("true");
            yield return new WaitForSeconds(0.2f);
        }


        while (amICloseTo(cam.transform.position, FindLevelObject(levelCamName).transform.position, 0.3f))
        {

            Vector3.Lerp(cam.transform.position, FindLevelObject(levelCamName).transform.position, 2);
            rotateCamTo(cam.transform, FindLevelObject(levelCamName).transform.forward, 2);

            yield return new WaitForSeconds(0.1f);
        }

    }

    public bool amICloseTo(Vector3 v1, Vector3 v2, float minDistance)
    {
        if (Vector3.Distance(v1, v2) > minDistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



    public void rotateCamTo(Transform t, Vector3 target, float speed)
    {
        t.rotation = Quaternion.Slerp(t.rotation, Quaternion.LookRotation(target - t.position), speed * Time.deltaTime);
    }

    public GameObject FindLevelGate(string levelName)
    {
        return GameObject.Find("level-gate"); //levelName
    }

    public GameObject FindLevelObject(string objectName)
    {
        return GameObject.Find(objectName); //levelName
    }

    public void syncLevelIn(string levelName)
    {
        StartCoroutine(iSyncLevelIn(levelName));
    }

    // Update is called once per frame
    void Update ()
    {

	}
}
