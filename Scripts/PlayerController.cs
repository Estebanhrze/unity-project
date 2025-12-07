using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 10f;
    public float playerSpeed = 10f;  
    public Sprite[] mySprites;
    private int index = 0;
    
    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    
    private bool isMoving = false;
    public GameManager myGameManager;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myGameManager = GameObject.FindFirstObjectByType<GameManager>(); 
        
        if (mySprites != null && mySprites.Length > 0)
        {
            mySpriteRenderer.sprite = mySprites[0];
        }
        
        StartCoroutine(WalkCoRutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("GoodItem"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore(1);
            myGameManager.AddCoin();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumpForce); 
        }

        float moveInput = 0;
        
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
            mySpriteRenderer.flipX = true;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
            mySpriteRenderer.flipX = false;
            isMoving = true;
        }
        else
        {
            isMoving = false;
            if (mySprites != null && mySprites.Length > 0)
            {
                mySpriteRenderer.sprite = mySprites[0];
            }
        }
        
        myrigidbody2D.linearVelocity = new Vector2(moveInput * playerSpeed, myrigidbody2D.linearVelocity.y);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            
            float direction = mySpriteRenderer.flipX ? -1 : 1;
            rb.linearVelocity = new Vector2(direction * bulletSpeed, 0);
        }
    }

    IEnumerator WalkCoRutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            
            if (isMoving && mySprites != null && mySprites.Length > 0)
            {
                mySpriteRenderer.sprite = mySprites[index];
                index++;
                if (index >= mySprites.Length)
                {
                    index = 0;
                }
            }
            else
            {
                index = 0;
            }
        }
    }
}