using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{

    public float speed;
    public float stopZPosition;
    public Vector3 zoomDisplace;
    public float zoomSize = 25;

    void Start()
    {
        zoomDisplace = gameObject.transform.position;
    }

    void Update()
    {
    }

    void OnMouseDown()
    {
        StartCoroutine("PopUp");
        PlayerPrefs.SetFloat("WorldRotation", transform.parent.rotation.x);
    }

    IEnumerator PopUp()
    {
        while (transform.localPosition.z < stopZPosition - 0.001f)
        {
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                new Vector3(transform.localPosition.x, transform.localPosition.y, stopZPosition),
                speed / 10 * Time.deltaTime
            );

            yield return null;
        }
    }

}
