using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHandController : MonoBehaviour
{

    public float speed;

    private bool inProgress;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && !inProgress)
        {
            StartCoroutine(ZoomIn());
        }
    }

    IEnumerator ZoomIn()
    {
        Vector3 startPos = transform.position;
        GameObject boy = GameObject.FindGameObjectWithTag("boy");
        Vector3 boyPos = boy.transform.localPosition;
        Vector3 targetPos = new Vector3(boyPos.x + 2, boyPos.y - 3, 0);
        inProgress = true;

        while (transform.localPosition.z > targetPos.z)
        {
            transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z - speed * Time.deltaTime);
            yield return null;
        }
        this.GetComponent<Collider2D>().enabled = true;

        yield return new WaitForSeconds(5);
        StartCoroutine(ZoomOutTo(startPos));
    }

    IEnumerator ZoomOutTo(Vector3 startPos)
    {
        this.GetComponent<Collider2D>().enabled = false;

        while (transform.localPosition.z < startPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * 5 * Time.deltaTime);
            yield return null;
        }

        transform.position = startPos;

        inProgress = false;
    }
}
