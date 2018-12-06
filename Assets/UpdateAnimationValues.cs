using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimationValues : MonoBehaviour
{
    public Animator animator;
    private float LastXPosition;
    private float CurrentXPosition;
    private float Speed;

    // Start is called before the first frame update
    void Start()
    {
        LastXPosition = transform.position.x;
        CurrentXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        LastXPosition = CurrentXPosition;
        CurrentXPosition = transform.position.x;
        Speed = (CurrentXPosition - LastXPosition) * 10 ;
      
   
        transform.rotation = new Quaternion(0f, 0f, 0f, 1);
        animator.SetFloat("Speed", Speed);
    }
}
