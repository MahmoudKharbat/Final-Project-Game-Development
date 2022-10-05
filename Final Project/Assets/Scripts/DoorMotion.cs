using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSrc;
    public string animationVarName = "";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool(animationVarName, true);
        //audioSrc.PlayDelayed(0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool(animationVarName, false);
        //audioSrc.PlayDelayed(0.5f);
    }
}