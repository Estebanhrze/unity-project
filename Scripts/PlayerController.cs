using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRendere mySpriteRenderer;

    //public GameObject Bullet;
    //public GameManager myGameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<mySpriteRenderer>();
        startCoroutine(WalkCoRutine());
        myGameManager = FindObjectOfType<GameManager>();
        
    }

        // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x,playerJumpForce);
        }
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
        /*
        if(Input.GetKeyDown(KeyCode.E)){
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }*/
    }


    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 6)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }
    
}
