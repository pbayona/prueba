using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//KEYS para nombres - {0,1,2,3,4,5,6,7,8,9}
//KEYS para scores - {score0, score1, score2, score3, score4, score5, score6, score7, score8, score9}

/* El esquema que se sigue cuando se entra al ranking es el siguiente
 * 
1 - Creamos una lista de usuarios y la rellenamos con usuarios nuevos a partir de los names y scores almacenados en PlayerPrefs.

  1.1 - Solo se almacenan hasta 10 usuarios.
	
2 - Una vez la lista está creada, sea el tamaño que sea, (max 10) se ORDENA.

3 - Luego recibimos el jugador nuevo que intenta entrar en el ranking en AddPlayer(Player p).

  3.1 - Si current_players (almacenada en playerPrefs y restaurada al hacer load() ) es menor a 10, entonces se mete directamente a la
  		lista y se incrementa current_players.
  3.2 - Si current_players es igual a 10 (el maximo) entonces hay que comparar la puntuacion del ultimo de la lista (ya que siempre
  		está ordenada) con la del jugador que quiere entrar. Si la puntuacion entrante es mayor a la del último en el ranking,
  		entonces se borrará al último y se meterá al nuevo
  		
4 - SE ORDENA LA LISTA Y SE GUARDA (almacenar en disco)

5 - Como último paso se ejecuta el OnGUI que recorrerá la lista de players y la muestra en pantalla 
*/
public class Leaderboard : MonoBehaviour

{
	public const int MAX_PLAYERS = 10;
	public static int current_players = 0;
	public static int highest_score;
	public static List<Player> players;
	public Text ranking;
		
	static void sort()
	{
		players.Sort(sortByScore);
	}

	static int sortByScore(Player p1, Player p2){ //Ordenar jugadores por puntuacion
		return p2.getScore ().CompareTo (p1.getScore());
	}

	static void save(){ //Recorre la lista de usuarios y los guarda
		int i = 0;
		foreach (Player player in players) {
			PlayerPrefs.SetInt ("Score"+i.ToString(),player.getScore());
			PlayerPrefs.SetString (i.ToString(),player.getName());
			i++;
		}
		PlayerPrefs.SetInt ("current_players",current_players);
	}

	static void load()
	{
		current_players = PlayerPrefs.GetInt ("current_players");
		if (current_players > 0) { //Llamo a todos los player prefs y los meto en la lista, luego los ordeno
			for (int i = 0; i < current_players; i++) { //Estan guardados con key en nombre 0,1, 2, 3, 4, etc. y con key en score0, score1, score2, score3
				players.Add (new Player(PlayerPrefs.GetString(i.ToString()),PlayerPrefs.GetInt("Score" + i.ToString())));
			}
			sort ();
		}
	}

	public static bool addPlayer(Player p)
	{		
		if (current_players < 10) { //Si hay menos de 10 players, se mete directamente
			players.Add (p);
			current_players++;
			sort ();
			save ();
			return true;
		} else if (current_players == 10){
			/* Hay que ver si puede entrar en el ranking por su puntuacion, si es así habrá que
			borrar el de puntuacion mas baja y meter a este	*/
			if (p.getScore () > getLowerScore()) {
				//print ("Score de entrada: " + p.getScore ());
				//print ("Score mas bajo en la lista: " + getLowerScore ());
				players.RemoveAt (9); 
				players.Add (p);
				sort ();
				save ();
				return true;
			}
		}
		return false;
	}

	void OnGUI() //Metodo que contiene todo lo que se ve en pantalla
	{
		string aux = "";
		foreach (Player player in players) { //Mostrar el ranking, recorre la lista de players (Siempre está ordenada por sort())
			aux += "\nName < " + player.getName() + " > " + "-----" + " Points < " + player.getScore().ToString() + " >";           
		}
		ranking.text = aux;
	}

	public static void instantiateList()
	{
		players = new List<Player> ();
		current_players = PlayerPrefs.GetInt ("current_players");
		load (); // Al cargar el script lleno la lista de usuarios guardados con los playerPrefs
	}

	private static int getLowerScore()
	{
		int higherIndex = players.Count - 1;
		int k = 0;
		foreach (Player player in players) { //Metodo que devuelve la puntuacion mas baja de todos los elementos de nuestra lista de usuarios
			if (k == higherIndex) {
				return player.getScore ();
			}
			k++;
		}
		return -1;
	}

	private static void deleteAllPlayerPrefs() //Este metodo borra todo lo que tenemos guardado en PlayerPrefs, nunca lo llamo lol pero ahi lo dejo xd
	{
		PlayerPrefs.DeleteAll ();
	}

	public void retry()
	{
		Application.LoadLevel("main_game");
	}

	public void quitGame()
	{
		Application.LoadLevel("start_window");
	}
}

