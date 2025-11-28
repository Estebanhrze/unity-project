using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 1f;
    public float playerSpeed = 10f;  
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();   
        StartCoroutine(WalkCoRutine());
    }

    void Update()
    {
        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumpForce); 
        }

        // Movimiento con teclas A/D
        float moveInput = 0;
        if (Input.GetKey(KeyCode.A)) moveInput = -1;
        if (Input.GetKey(KeyCode.D)) moveInput = 1;
        
        myrigidbody2D.linearVelocity = new Vector2(moveInput * playerSpeed, myrigidbody2D.linearVelocity.y);
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        
        if (mySprites != null && mySprites.Length > 0)
        {
            mySpriteRenderer.sprite = mySprites[index];
            index++;
            if (index >= mySprites.Length)
            {
                index = 0;
            }
        }
        
        StartCoroutine(WalkCoRutine());
    }
}