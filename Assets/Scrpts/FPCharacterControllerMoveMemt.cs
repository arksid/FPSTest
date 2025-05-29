using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharacterControllerMoveMemt : MonoBehaviour
{
    private CharacterController characterController;


    private Transform characterTransform;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterTransform = GetComponent<Transform>();

    }

    private void Update()
    {
        var tmp_Horizontal = Input.GetAxis("Horizontal");
        var tmp_Vertical = Input.GetAxis("Vertical");

    }
}
