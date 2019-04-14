using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class StartWindow : MonoBehaviour {

    public GUIStyle style;
    public GUIStyle style1;

	void OnGUI () {

        GUI.Label(new Rect(50,50, 1000, 500), "Space Invaders", style);

        if (GUI.Button(new Rect(50, 150, 430, 36), "- Play: +13 game", style1))
        {
            Application.LoadLevel("main_game");
            //SceneManager.LoadScene("main_game", LoadSceneMode.Additive);
        }
        if (GUI.Button(new Rect(50, 250, 510, 75), "- Play: non-violent\ngame", style1))
        {
            Application.LoadLevel("kids_game");
        }
    }
	
}
