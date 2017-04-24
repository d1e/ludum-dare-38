using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public GameManagement gm;

    public string levelName;

    void Start()
    {
        gm = GameObject.Find("game manager").GetComponent<GameManagement>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        print("in");
        if (collision.tag == "giant")
        {
            GameObject g = GameObject.Find("Canvas");
            g.GetComponent<uiManager>().showhideUIElement("enterLevelButton", true);
            gm.nearestLevel = levelName;
        }

    }

    void OnTriggerExit (Collider collision)
    {
        if (collision.tag == "giant")
        {
            GameObject g = GameObject.Find("Canvas");
            g.GetComponent<uiManager>().showhideUIElement("enterLevelButton", false);
            gm.nearestLevel = "none";
        }
    }

    //void OnMouseDown()
    //{
    //    StartCoroutine("PopUp");
    //    PlayerPrefs.SetFloat("WorldRotation", transform.parent.rotation.x);
    //}

    //IEnumerator PopUp()
    //{
    //    while (transform.localPosition.z < stopZPosition - 0.001f)
    //    {
    //        transform.localPosition = Vector3.Lerp(
    //            transform.localPosition,
    //            new Vector3(transform.localPosition.x, transform.localPosition.y, stopZPosition),
    //            speed / 10 * Time.deltaTime
    //        );

    //        yield return null;
    //    }
    //}

}
