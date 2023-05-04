using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float velocidadaMov;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask queEsSuelo;
    private void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        rb2d.velocity= new Vector2(velocidadaMov* transform.right.x,rb2d.velocity.y);
        RaycastHit2D informacionSuelo= Physics2D.Raycast(transform.position, transform.right,distancia,queEsSuelo);
        if(informacionSuelo){
            Girar();
        }
    }
    private void Girar(){
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180,0 );
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color= Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distancia);
    }
}
