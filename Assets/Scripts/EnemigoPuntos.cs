using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPuntos : MonoBehaviour
{
    public int valor1=1;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collisio){
        //
        if(collisio.CompareTag("balas")){
            gameManager.SumarPuntos(valor1);
            Destroy(this.gameObject);
        }
    }
}
