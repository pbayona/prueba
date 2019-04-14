using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour {

    public void playArcadeGame()
    {
        Application.LoadLevel("main_game");
    }

    public void playSurvivalGame()
    {
        Debug.Log("Aquí tienes tu tortura.");
        Application.LoadLevel("kids_game");
    }

    public void showConfig(GameObject config)
    {
        if (config.activeInHierarchy)
        {
            config.SetActive(false);
        }
        else
        {
            config.SetActive(true);
        }
    }

    public void bouncingBullets()
    {
        Database.invertBouncingBullets();
    }
}
