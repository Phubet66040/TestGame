using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Contro : MonoBehaviour
{
    public float moveX;
    public float JumpFocre;
    private Rigidbody2D rb;
    public float speed;
    private int score;
    public Text scoreUI;
    public bool isJumpping;
    private void Start(){

        rb = GetComponent<Rigidbody2D>();

    }
    private void Update(){
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX*speed,rb.velocity.y);
        if( Input.GetButtonDown("Jump")){
            if(isJumpping != true){
                rb.AddForce(new Vector2(rb.velocity.x,JumpFocre*100));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.CompareTag("Floor")){
            isJumpping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D target){
        if(target.gameObject.CompareTag("Floor")){
            isJumpping = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.CompareTag("Coin")){
            score +=10;
            scoreUI.text = "Score = " + score.ToString();
            Destroy(target.gameObject);
        }
         if(target.gameObject.CompareTag("Enemy")){
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
