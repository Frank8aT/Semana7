using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public AudioClip Sound;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            
            bool vidaRecuparada = GameManager.Instance.RecuperarVida();
            if(vidaRecuparada){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            Destroy(this.gameObject);
            }
        }
    }

}
