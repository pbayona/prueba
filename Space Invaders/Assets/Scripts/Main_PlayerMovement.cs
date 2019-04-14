using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main_PlayerMovement : MonoBehaviour
{
    //Movement info
    public static Vector3 position;     //Para que las balas sepan calcular su dirección al rebotar.

    //Movement vars
    private Vector3 movement = Vector3.zero;
    private CharacterController controller;
    private int playerSpeed = 10;
    public GameObject bullet;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
		movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        movement = transform.TransformDirection(movement);              //From local to global coordinates
        movement *= playerSpeed;                                        

        controller.Move(movement * Time.deltaTime);                     //Time.deltaTime para que no dependa de fps
        position = transform.position;

        if (Input.GetKeyUp("space"))
        {
            AudioManager.PlayShoot();

            GameObject spawn_bullet = Instantiate(bullet, transform.position + new Vector3(0.7f, 0, 0), Quaternion.Euler(0, 0, 0));
            spawn_bullet.GetComponent<Rigidbody>().AddForce(Vector3.right * 500);

        }
    }
    
}
