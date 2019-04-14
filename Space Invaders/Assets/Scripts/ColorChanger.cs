using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour { /*Script asignado a cada alien, por lo que tiene el renderer de ese gameobject
    Un gameObject no tiene un material, sino un renderer, y puede que a ese renderer tenga un material asignado*/

    public Material [] materials;
    public Renderer rend;
	private int aux; //entero auxiliar para asegurarme de que cambie si o si de color al haber varias colisiones simultaneas
	//Puede ocurrir que se vuelva a generar el mismo indice y por lo tanto no cambie de material.
    private int i;

	void Start () {
        rend = GetComponent<Renderer>(); //Pillo el renderer del gameObject       
        rend.enabled = true;
		aux = Random.Range(0,4);
    }

    public void RandomChangeColor() //Como está asignado a cada alien por individual, el indice que se genera en cada alien es distinto
	//y por tanto, el material que pillará cada uno será aleatorio 
    {
		do{
			i = Random.Range (0,4);
		}
		while (i == aux); //Se saldrá del bucle cuando el material que vaya a poner sea distinto al último
			rend.sharedMaterial = materials [i];
			aux = i; //Aqui pilla aux el valor del ultimo indice generado
    }

	public void ChangeColor(int j) //Método que asigna a todos los enemigos el mismo material
	{
		//Recibe como argumento el entero que se ha generado aleatoriamente para todos por igual
		rend.sharedMaterial = materials[j];
	}

}
