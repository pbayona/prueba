using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    public GUISkin style;
    public int current_score = 0;
    public static int current_enemies = 65;

    public void OnGUI()
    {
        GUI.skin = style;
        GUI.Label(new Rect(10, 20, 200, 50), "SCORE < " + current_score.ToString() + " >");
    }

    public void Update()
    {
        if (current_enemies == 0)
        {
            print("You win");
        }
    }
}
