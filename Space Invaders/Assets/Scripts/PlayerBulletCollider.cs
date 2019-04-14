using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : MonoBehaviour
{
    private static GameObject player;
    private bool friendlyFire;

    private int bounces = 0;
    private const int MAX_BOUNCES = 5;
    private const int SPEED = 500;
	private int aux;
	 

	void Start()
	{
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Counter(1));
		aux = 0;
    }



    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy")
        {
			Database.enemies.Remove (col.gameObject);
            AudioManager.PlayKill();
            Database.killedEnemy();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Boss")
        {
			GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera"); /*Pillo la camara ya que necesito llamar a un metodo
				de database y por estáticos peta*/
			camera.SendMessage ("callRespawn");
            AudioManager.PlayKill();
            Destroy(gameObject);
            Destroy(col.gameObject);
            Database.current_score += 150;

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

            if (bounces< MAX_BOUNCES && Database.bouncingBullets)
            {
                Rigidbody bulletRig = GetComponent<Rigidbody>();

                Vector3 bulletToPlayer = new Vector3 (Main_PlayerMovement.position.x - transform.position.x, 
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
        else if (col.gameObject.tag == "Player")
        {
            if (friendlyFire)
            {
                Database.hitPlayer();
                Destroy(gameObject);
            }
        }
        else if(col.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
		else if(col.gameObject.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            Debug.Log("Colisión no contemplada con " + col.gameObject.name);
        }
    }

    IEnumerator Counter(int time)
    {
        yield return new WaitForSeconds(time);
        friendlyFire = true;
    }
}
