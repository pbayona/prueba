using UnityEngine;
using System.Collections;

public class Kids_PlayerMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private CharacterController controller;
    private int playerSpeed = 10;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        movement = transform.TransformDirection(movement);  //From local to global coordinates

        movement *= playerSpeed;

        controller.Move(movement * Time.deltaTime);
    }

}