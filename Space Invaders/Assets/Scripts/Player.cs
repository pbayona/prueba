using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private string name;
	private  int score;

	#region UI

	public Player(string n, int s)
	{
		name = n;
		score = s;
	}

	public void setName(string n)
	{
		name = n;
	}

	public void setScore(int s)
	{
		score = s;
	}

	public string getName()
	{
		return name;
	}

	public int getScore()
	{
		return score;
	}

	#endregion

}
