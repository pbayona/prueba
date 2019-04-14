using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour
{
    public GameObject enemy_bullet;
    private float countdown;

    void Start()
    {
        //Asign enemies to the list
        countdown = Random.Range(Database.enemy_shotMinTime, Database.enemy_shotMaxTime);
    }

    void Update()
    {
        if (countdown <= 0)
        {
            //Dispara
            if (Random.Range(0, Database.chancesOfShooting) == 0)
            {
				GameObject fire_bullet = Instantiate(enemy_bullet, transform.position, Quaternion.Euler(0,0,0));
                fire_bullet.GetComponent<Rigidbody>().AddForce(-Vector3.right * 400);
            }

            //Instancia un nuevo timer
            countdown = Random.Range(Database.enemy_shotMinTime, Database.enemy_shotMaxTime);
        }
        else
        {
            countdown--;
        }
    }
}
