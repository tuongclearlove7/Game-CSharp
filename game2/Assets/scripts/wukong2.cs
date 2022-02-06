/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wukong2 : MonoBehaviour
{
    private Rigidbody2D rb2D;
    
    private float moveseed;
    private float jumpForce;
    private bool jumping;
    private float moveHorizontal;
    private float moveVertical;

    void Start(){
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveseed = 3f;
        jumpForce = 60f;
        jumping = false;
    }
    void Update(){
        moveHorizontal = Input GetAxisRaw("Horizontal");
        moveVertical = Input GetAxisRaw("Vertical");
    }
    void FixedUpdate(){
        if ()
        {

        }
    }
}

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wukong2 : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D Rigidbody_2D;
    private Animator canimation;
    bool jump_up;

private void Awake(){
        Rigidbody_2D = GetComponent<Rigidbody2D>();
        canimation = GetComponent<Animator>();
}

private void Update(){
    float horizontalInput = Input.GetAxis("Horizontal");
    Rigidbody_2D.velocity = new Vector2(horizontalInput * speed, Rigidbody_2D.velocity.y);
        
    if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(3,3,3);

    else if (horizontalInput < -0.01)
            transform.localScale = new Vector3(-3, 3, 3);
            canimation.SetBool("run", horizontalInput != 0);
             
    if (canimation && horizontalInput > 0.01f){
            Debug.Log("you are moving right");
            canimation.SetBool("dance", false);
            canimation.SetBool("attack", false);// tấn công
            canimation.SetBool("dodge", false);// né          
        }
    else if (horizontalInput < -0.01){
            Debug.Log("you are moving left");
            canimation.SetBool("dance", false);
            canimation.SetBool("attack", false);
            canimation.SetBool("dodge", false);
        }
    else if (Input.GetKey(KeyCode.Space)){
            canimation.SetBool("attack", true);
            Debug.Log("You are attacking");
        }
    else if (Input.GetKey(KeyCode.Tab)){
            canimation.SetBool("dance", true);
            Debug.Log("You are dancing");
    }
    else if (Input.GetKey(KeyCode.DownArrow)){
            canimation.SetBool("dodge", true);
            Debug.Log("You are dodging");
    }

    if (Input.GetKeyDown(KeyCode.UpArrow) && jump_up){
            Debug.Log("you are jumping");
            jump_up = false;
            Rigidbody_2D.velocity = new Vector2(Rigidbody_2D.velocity.x, speed);
            canimation.SetBool("jump",true);// nhảy
        }
    }

void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "jump2"){
            jump_up = true;
            canimation.SetBool("jump",false);
        }     
    }   
}




















