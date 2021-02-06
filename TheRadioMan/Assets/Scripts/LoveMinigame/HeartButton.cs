using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartButton : MonoBehaviour
{
    Animator animator;
    public HeartManager manager;
    public GameObject heartPointer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ 
            animator.SetTrigger("Press");
            heartPointer.GetComponent<Animator>().SetTrigger("Press");

            manager.ButtonPressed();
        }
    }
}
