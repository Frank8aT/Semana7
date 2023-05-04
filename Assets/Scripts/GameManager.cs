using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
	public HUDScript hud;
	public AudioClip soundMoneda;
	public AudioClip SonidoVidaPerdida;

    public int PuntosTotales {get; private set;}
	//
	//public int PuntostotLlave{get; private set;}
//
	private int vidas = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManager en escena.");
        }
    }
	//
	/*public void SumarLlave(int puntosLlave){
		PuntostotLlave+=puntosLlave;
		hud.ActualizarPuntos(PuntostotLlave);
	}*/
	//

    public void SumarPuntos(int puntosASumar)
    {
        PuntosTotales += puntosASumar;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(soundMoneda);
		hud.ActualizarPuntos(PuntosTotales);
		//cambio de escena
		if(PuntosTotales ==10){
            SceneManager.LoadScene(1);
		}
    }

	public void PerderVida() {
		vidas -= 1;
		Camera.main.GetComponent<AudioSource>().PlayOneShot(SonidoVidaPerdida);
		if(vidas == 0)
		{
			// Reiniciamos el nivel.
			SceneManager.LoadScene(0);
		}

		hud.DesactivarVida(vidas);
	}

	public bool RecuperarVida() {
		if (vidas == 3)
		{
			return false;
		}

		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
	}

}
