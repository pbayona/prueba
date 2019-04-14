using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GUIStyle style;
    public GUIStyle labStyle;
    public GUIStyle pStyle;
    public string label_text = "YOU LOSE";
    public int points; //Variable que me permite no hacer 2 finishGames, si la puntuacion es
                //0 es que no has matado a ningún marciano (modo niños) y por lo tanto
                //no se muestra el label
                //GUI
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 1000, 500), label_text, labStyle);
        points = Database.current_score;

        if (points > 0)
        {
            GUI.Label(new Rect(40, 150, 500, 250), "Points < " + points.ToString() + " >", pStyle);
        }

        if (GUI.Button(new Rect(40, 100, 195, 42), "RETRY", style))
        {
            //Reload
            Application.LoadLevel(Database.lastLoadedGame);
        }
        if (GUI.Button(new Rect(40, 200, 370, 42), "QUIT GAME", style))
        {
            //Reload
            Application.LoadLevel("start_window");
        }
		if (GUI.Button(new Rect(40, 300, 370, 42), "Ranking", style))
		{
			//Reload
			Application.LoadLevel("user_input");
		}
    }
}
