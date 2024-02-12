using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject Companion;
    public Animator p_animator;


    // Start is called before the first frame update
    void Start()
    {
        p_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //p_animator.SetBool("isGoingUp", isGoingUp);
        //p_animator.SetFloat("Down", v);
        //p_animator.SetFloat("Left", h);
        //p_animator.SetFloat("Right", h);
    }
}
