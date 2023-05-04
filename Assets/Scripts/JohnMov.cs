using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMov : MonoBehaviour
{
    // Start is called before the first frame update
    //prefabbala
    public GameObject BulletPreFab;
    //variables salto
    public float Speed;
    public float jumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    //salto solo una vez
    private bool Grounded;
    private float LastShoot;
    //vida jhon 
    private int Health=15;
    public AudioClip Sound;
    public AudioClip Sound2;

    //balasmunición
    public TMPro.TextMeshProUGUI textoContBalas;
    public TMPro.TextMeshProUGUI textoConLlave;
    int cantBalas=0;

    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
        Animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal=Input.GetAxisRaw("Horizontal");
        //animaciones
        if(Horizontal<0.0f) transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
        else if(Horizontal>0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        Animator.SetBool("running",Horizontal!= 0.0f);
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded=true;
        }
        else Grounded= false;
        //salto
        if(Input.GetKeyDown(KeyCode.W) && Grounded){
           // Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
            Jump();
        }
        if(Input.GetKey(KeyCode.Space)&& Time.time> LastShoot+0.25f){
            Shoot();
            LastShoot=Time.time;
        }
        //balas cant 

        textoContBalas.text = cantBalas.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D colli){
        if(colli.gameObject.CompareTag("balas")){
            
            Destroy(colli.gameObject);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound2);
            cantBalas+=5;
        }
    }
    private void Jump(){
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        Rigidbody2D.AddForce(Vector2.up*jumpForce);
        
    }
    private void Shoot(){
        Vector3 direction;
        if(cantBalas>0){
        if(transform.localScale.x== 1.0f)direction =Vector3.right;
        else direction =Vector3.left;
        GameObject bullet = Instantiate(BulletPreFab,transform.position + direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        cantBalas-=1;
        }
        //else cantBalas-=1;
    }
    private void FixedUpdate(){
        Rigidbody2D.velocity= new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    public void Hit(){
        Health= Health-1;
        if(Health==0)Destroy(gameObject);
    }
}
