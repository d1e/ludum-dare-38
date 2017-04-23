using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantController : MonoBehaviour {

    private Animator animator;

    void Start() {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger("Direction", 1);
            animator.SetBool("Moving", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetInteger("Direction", 2);
            animator.SetBool("Moving", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetInteger("Direction", 0);
            animator.SetBool("Moving", false);
        }
    }
}
