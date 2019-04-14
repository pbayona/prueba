using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollider : MonoBehaviour
{
    private int bounces = 0;
    private const int MAX_BOUNCES = 5;
    private const int SPEED = 300;

    public void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Database.hitPlayer();
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Colisión");
            AudioManager.PlayExplosion();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Barrier")
        {	
			Database.collisions++;	
			if (Database.collisions == 1) {
				GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
				//Database.call ();
				camera.SendMessage ("call");
			}
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
		else if (col.gameObject.tag == "Bound") /*Hay que mirar esto */
        {
            bounces++;

            if (bounces < MAX_BOUNCES && Database.bouncingBullets)
            {
                Rigidbody bulletRig = GetComponent<Rigidbody>();

                Vector3 bulletToPlayer = new Vector3(Main_PlayerMovement.position.x - transform.position.x,
                    Main_PlayerMovement.position.y - transform.position.y, 0);
                bulletToPlayer = Vector3.Normalize(bulletToPlayer);

                bulletRig.velocity = Vector3.zero;

                bulletRig.AddForce(bulletToPlayer * (SPEED + bounces * 50));
                transform.LookAt(transform.position + bulletToPlayer);
                transform.Rotate(90, 0, 0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
