using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour {
    private Animator animator;
    //public AudioClip clip;
    //private AudioSource source;
	// Use this for initialization

	void Start () {
        animator = this.GetComponent<Animator>();
        //source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Punch");
            //source.PlayOneShot(clip);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            //Debug.Log("Jump Called");
        }

    }
}
