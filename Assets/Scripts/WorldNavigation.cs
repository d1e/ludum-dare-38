using UnityEngine;

public class WorldNavigation : MonoBehaviour
{

    public float speed;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RotateXBy(-speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RotateXBy(speed);
        }
    }

    void RotateXBy(float x)
    {
        transform.Rotate(new Vector3(x, 0, 0) * Time.deltaTime);
    }
}
