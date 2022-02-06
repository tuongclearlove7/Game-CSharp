using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wukong : MonoBehaviour
{

Animator m_animation;
public Rigidbody2D m_rigidbody2D;
bool jump_up;
public float Movespeed;
public float jumpspeed;

private void Awake()
{
    m_rigidbody2D = GetComponent<Rigidbody2D>();
    m_animation = GetComponent<Animator>();
}
private void FixedUpdate()
{
    Movehandle();
    Flip();
}
    




void Movehandle()
    {
        if (controls.Ins.Moveleft)
        {
            if (m_rigidbody2D)
                m_rigidbody2D.velocity = new Vector2(-1f, m_rigidbody2D.velocity.y) * jumpspeed;

            if (m_animation)
            m_animation.SetBool("run", true);
            m_animation.SetBool("dance", false);
            m_animation.SetBool("attack", false);// tấn công
            m_animation.SetBool("dodge", false);// né
        }
        else if (controls.Ins.Moveright)
        {
            if (m_rigidbody2D)
                m_rigidbody2D.velocity = new Vector2(1f, m_rigidbody2D.velocity.y) * jumpspeed;
            
            if (m_animation)
            m_animation.SetBool("run", true);
            m_animation.SetBool("dance", false);
            m_animation.SetBool("attack", false);
            m_animation.SetBool("dodge", false);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            m_animation.SetBool("attack", true);
            Debug.Log("You are attacking");
        }
        else if (Input.GetKey(KeyCode.Tab))
        {
            m_animation.SetBool("dance", true);
            Debug.Log("You are dancing");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_animation.SetBool("dodge", true);
            Debug.Log("You are dodging");
        }  
        else
        {
            if (m_rigidbody2D)
                m_rigidbody2D.velocity = new Vector2(0, m_rigidbody2D.velocity.y);

            if (m_animation)
                m_animation.SetBool("run", false);
        }
    }





void Update()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow) && jump_up)
        {   
                Debug.Log("you are jumping");
                jump_up = false;
                m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, jumpspeed);
                m_animation.SetBool("jump",true);// nhảy
        }
    }    

void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.tag == "jump2")
    {
        jump_up = true;
        m_animation.SetBool("jump",false);
    }     
}





void Flip()
    {
        if (controls.Ins.Moveleft)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (controls.Ins.Moveright)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
































