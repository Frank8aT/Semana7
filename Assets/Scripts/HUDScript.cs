/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    public GameObject [] vidas;
    void Update()
    {
        puntos.text= gameManager.PuntosTotales.ToString();
    }
    public void ActualizarPuntos(int puntosTotales){
        puntos.text=puntosTotales.ToString();
    }
    public void DesactivarVida(int indice){
        vidas[indice].SetActive(false);
    }
    public void ActivarVida(int indice){
        vidas[indice].SetActive(true);
    }
}*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI puntos;
	public GameObject[] vidas;
    
	void Update () {
		puntos.text = GameManager.Instance.PuntosTotales.ToString();
	}
	public void ActualizarPuntos(int puntosTotales)
	{
		puntos.text = puntosTotales.ToString();
	} 

	public void DesactivarVida(int indice) {
		vidas[indice].SetActive(false);
	}

	public void ActivarVida(int indice) {
		vidas[indice].SetActive(true);
	}
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI puntos;
	//public TextMeshProUGUI llave;
	public GameObject[] vidas;
    
	void Update () {
		puntos.text = GameManager.Instance.PuntosTotales.ToString();
	}

	public void ActualizarPuntos(int puntosTotales)
	{
		puntos.text = puntosTotales.ToString();
	} 
	/*public void ActualizarPuntosLlave(int cantLlave){
		llave.text= GameManager.Instance.PuntostotLlave.ToString();

	}*/

	public void DesactivarVida(int indice) {
		vidas[indice].SetActive(false);
	}

	public void ActivarVida(int indice) {
		vidas[indice].SetActive(true);
	}
}