using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemBad"))
        {
            GameManager gameManager = GameObject.FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(10);
            }
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Destroy(gameObject, 3f);
    }
}