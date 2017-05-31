using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight;
    public float speed = 0.4f;
    private Animator anim;
    private GameObject playerSprite;

    private void Awake()
    {
        rb2d = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
        playerSprite = transform.Find("PlayerSprite").gameObject;
        anim = (Animator)playerSprite.GetComponent(typeof(Animator));
    }
   
	void Update ()
    {
        float movePlayerVector = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(movePlayerVector));
        rb2d.velocity = new Vector2(movePlayerVector * speed, rb2d.velocity.y);
        if(movePlayerVector > 0 && !facingRight)
        {
            Flip();
        }
        else if (movePlayerVector < 0 && facingRight)
        {
            Flip();
        }
	}
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = playerSprite.transform.localScale;
        theScale.x *= -1;
        playerSprite.transform.localScale = theScale;
    }
}
