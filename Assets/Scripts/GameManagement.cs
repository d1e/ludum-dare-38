using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    AsyncOperation async1;
    AsyncOperation async2;
    AsyncOperation async3;
    AsyncOperation async4;

    // Use this for initialization

    public string nearestLevel = "none";
    public List<string> levelsCompleted = new List<string>();
    public Vector3 camOrigin;
    public GiantController giantController;
    public UICharInfo manager;

    void Start () 
	{
        BeginGame();
    }

    public void SetCameraPosition()
    {
        GameObject cam = GameObject.Find("Camera");
        camOrigin = cam.transform.position;
    }

    public void LoadMenu()
    {
        //async1 = SceneManager.LoadSceneAsync("titlemenu", LoadSceneMode.Additive);
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

        giantController = GameObject.Find("Giant").GetComponent<GiantController>();

        SetCameraPosition();

        GameObject g = GameObject.Find("Main Camera");
        g.SetActive(false);
    }

    public IEnumerator iSyncLevelIn(string levelName)
    {
        GameObject g = GameObject.Find("level-gate-" + levelName);

        giantController.stopInput = true;
        string levelCamName = levelName + "Cam";
        GameObject cam = GameObject.Find("Camera");

        //load level
        async3 = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        //wait
        while (!async3.isDone)
        {
            print("true");
            yield return new WaitForSeconds(0.2f);
        }

        //positon the level
        //FindLevelObject(levelName).transform.position = g.transform.position;
        FindLevelObject(levelCamName).GetComponent<Camera>().enabled = true;
        
        //move camera to the level
        float elapsedTime = 0;
        float time = 10;
        float fadeSpeed = Time.deltaTime * 0.5f;

        float fade = 1;
        while (elapsedTime < time)
        {
            //fade out the sprite
            fade -= fadeSpeed;
            Mathf.Clamp(fade, 0, 1);
            g.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, fade);
            
            //movecam
            cam.transform.position = Vector3.Lerp(cam.transform.position, FindLevelObject(levelCamName).transform.position, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        g.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0);

        //rotateCamTo(cam.transform, FindLevelObject(levelCamName).transform.forward, 2);
    }


    public IEnumerator iSyncLevelOut(string levelName)
    {
        
        GameObject cam = GameObject.Find("Camera");
        GameObject g = GameObject.Find("level-gate-" + levelName);

        

        //move camera to the level
        float elapsedTime = 0;
        float time = 4;
        float fadeSpeed = Time.deltaTime * 0.5f;
        float fade = 0;
        while (elapsedTime < time)
        {
            //fade out the sprite
            fade += fadeSpeed;
            Mathf.Clamp(fade, 0, 1);
            g.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, fade);


            //movecam
            cam.transform.position = Vector3.Lerp(cam.transform.position, camOrigin, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        g.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1);
        cam.transform.position = camOrigin;

        //unload level
        async4 = SceneManager.UnloadSceneAsync(levelName);


        //wait
        while (!async4.isDone)
        {
            print("unloading");
            yield return new WaitForSeconds(0.2f);
        }

        giantController.stopInput = false;
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
        if(Input.GetKeyDown(KeyCode.R))
        {
            print("hit");
            StartCoroutine(iSyncLevelOut("boylevelone"));
        }
        
	}
}
