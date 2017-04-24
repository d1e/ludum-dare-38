using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

    public GameManagement gm;
    public Transform enterLevelButton;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("game manager").GetComponent<GameManagement>();
        enterLevelButton = GameObject.Find("enterLevelButton").transform;
        showhideUIElement("enterLevelButton", false);
	}

    public void showhideUIElement(string elementName, bool active)
    {
        switch (elementName)
        {
            case "enterLevelButton": enterLevelButton.gameObject.SetActive(active);
                break;
        }
    }

    public void syncLevelIn()
    {
        gm.syncLevelIn(gm.nearestLevel);
    }

    // Update is called once per frame
        void Update () {
		
	}
}
