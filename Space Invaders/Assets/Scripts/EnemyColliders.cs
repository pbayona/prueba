using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {

        if (gameObject.tag != "Boss")
        {
            if (col.gameObject.name == "Top_Barrier")
            {
                //Debug.Log("HOLA WEEEY");
                EnemyMovement.goUp = false;
                EnemyMovement.goLeft = true;
            }
            else if (col.gameObject.name == "Bottom_Barrier")
            {
                EnemyMovement.goUp = true;
                EnemyMovement.goLeft = true;
            }
            else if (col.gameObject.name == "Left_Barrier")
            {
                Debug.Log("Un marciano escapó!!!");
            }
            else if (col.gameObject.name == "Player")
            {
                Database.hitPlayer();
            }
            else if (col.gameObject.tag == "Barrier")
            {
                Destroy(col.gameObject);
            }
        }
        else if(gameObject.tag == "Boss")
        {
            if (col.gameObject.name == "Bottom_Barrier")
            {	
				Debug.Log ("El boss ha muerto");
				GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera"); /*Pillo la camara ya que necesito llamar a un metodo
				de database y por estáticos peta */ 
				camera.SendMessage ("callRespawn");
                Destroy(gameObject);
            }
        }


    }

}
