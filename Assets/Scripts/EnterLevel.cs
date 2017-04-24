using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public GameManagement gm;

    public string levelName;
    public GameObject LevelOverlay;

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

    public void RevealLevelUnderneath()
    {

    }

    public void HideLevelUnderneath()
    {
        
    }

}
