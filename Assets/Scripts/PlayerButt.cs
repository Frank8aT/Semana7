using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    bool isLeft = false;
    bool isRight= false;
    bool isjump= false; 
    bool canJump =true;
    public Rigidbody2D rb;
    public float speedForce1;
    public float jumpForce1;
    public float waitJump;
    public AudioClip SoundButton;
    //public Animator anim;
    public void clickLeft(){
        isLeft=true;
    }
    public void releaseLeft(){
        isLeft= false;
    }
    public void clickRight(){
        isRight= true;
    }
    public void releaseRight(){
        isRight=false;
    }
    public void clickJump(){
        isjump=true;
    }
    private void FixedUpdate(){
        if(isLeft){
            transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
            rb.AddForce(new Vector2(-speedForce1,0)* Time.deltaTime);
        }
        if(isRight){
            transform.localScale = new Vector3(1.0f,1.0f,1.0f);
            rb.AddForce(new Vector2(speedForce1, 0)* Time.deltaTime);
        }
        if(isjump&&canJump){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundButton);
            isjump=false;
            rb.AddForce(new Vector2(0,jumpForce1));
            canJump=false;
            Invoke("waitToJump", waitJump);
        }
    }
    void waitToJump(){
        canJump=true;
    }
}
