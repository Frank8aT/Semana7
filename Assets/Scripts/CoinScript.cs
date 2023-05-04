using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int valor=1;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collisio){
        //
        if(collisio.CompareTag("Player")){
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
        //
    }
}
