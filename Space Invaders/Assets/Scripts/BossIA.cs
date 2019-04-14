using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIA : MonoBehaviour {

	public GameObject enemy_bullet;

	// Use this for initialization
	void Start () {
		StartCoroutine (BossShoot (0.7f));
	}
		
	public IEnumerator BossShoot(float time)
	{
		while(1==1){	//jaja 1 siempre es igual a 1 lol xd
			yield return new WaitForSecondsRealtime (time);
			GameObject fire_bullet = Instantiate (enemy_bullet, transform.position, Quaternion.Euler (0, 0, 90));
			fire_bullet.GetComponent<Rigidbody> ().AddForce (-Vector3.right * 400);
		}
	}
}
