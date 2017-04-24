using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCameraController : MonoBehaviour
{

    public GameObject boy;
    public float minPosX;
    public float maxPosX;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(
            getXPositionInLevelBounds(),
            transform.position.y,
            transform.position.z
        );
    }

    private float getXPositionInLevelBounds()
    {
        if (boy.transform.position.x <= minPosX)
        {
            return minPosX;
        }
        else if (boy.transform.position.x >= maxPosX)
        {
            return maxPosX;
        }
        else
        {
            return boy.transform.position.x;
        }
    }
}
