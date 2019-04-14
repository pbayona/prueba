using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	public InputField entrada;//El objeto que tiene el campo de texto que utilizamos para pillar el input del player
	public Text salida; //Mostrar mensaje de error si entrada vacia y ok pulsado
	public GUIStyle labStyle;

	public void ok(){ /* Este metodo recibe por teclado un texto que será el nombre del jugador, si el nombre no es
	vacío, se carga la escena del ranking y se instancia la lista que contiene a los 10 mejores jugadores (esta lista se instancia 
	cada vez que se accede al ranking, es asumible ya que solo hay 10 jugadores). Para más info ir al script Leaderboard*/
		if(entrada.text.Length > 10)
        {
            salida.text = "The name must be shorter than 10 letters.";
        }
        else if (entrada.text != null && entrada.text != "" ) {
			Application.LoadLevel ("leaderboard");
			Player aux = new Player (entrada.text, Database.current_score);
			Leaderboard.instantiateList ();
			if (Leaderboard.addPlayer (aux)) {
				Debug.Log ("Se ha creado un jugador y se ha añadido al ranking");
			} else {
				Debug.Log ("El jugador no se ha añadido al ranking");
			}
		} else {
			salida.text = "Please introduce your name before pressing the OK button";
		}
	}

	public void Clear(){
		entrada.text = "";
		salida.text = "";

	}
		
}
