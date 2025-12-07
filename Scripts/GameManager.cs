using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textCoins; 
    
    private int score = 0;
    private int coins = 0; 

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        UpdateCoinsUI(); 
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinsUI();
    }

    void UpdateScoreUI()
    {
        textScore.text = "Score: " + score;
    }

    void UpdateCoinsUI()
    {
        textCoins.text = "Coins: " + coins;
    }
}