using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveMent : MonoBehaviour
{

    private Transform characterTransform;
    private Rigidbody characterRigidbody;
    public float Speed;
    public float JumpHeight;
    public float gravity;

    private bool IsGrounded;
    private void Start()
    {
        characterTransform = transform;
        characterRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(IsGrounded)
        {
            var tmp_Horizontal = Input.GetAxis("Horizontal");
            var tmp_Vertical = Input.GetAxis("Vertical");


            var tmp_CurrentDirection = new Vector3(tmp_Horizontal, 0, tmp_Vertical);
            tmp_CurrentDirection = characterTransform.TransformDirection(tmp_CurrentDirection);
            tmp_CurrentDirection *= Speed;

            var tmp_CurrentVelocity = characterRigidbody.velocity;
            var tmp_VelocityChange = tmp_CurrentDirection - tmp_CurrentVelocity;

            tmp_VelocityChange.y = 0;

            characterRigidbody.AddForce(tmp_VelocityChange, ForceMode.VelocityChange);

            if(Input.GetButtonDown("Jump"))
            {
                characterRigidbody.velocity = new Vector3(tmp_CurrentVelocity.x, CalculateJumpheightSpeed(), tmp_CurrentVelocity.z);
            }
        }
        characterRigidbody.AddForce(0, -gravity*Time.deltaTime, 0);
    }
    private float CalculateJumpheightSpeed()
    {
        return Mathf.Sqrt(2 * gravity * JumpHeight);
    }

    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
