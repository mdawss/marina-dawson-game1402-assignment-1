using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string SceneName;
    
    public int CurrentCoins;
    public int MaxCoins;
    
    public int minHealth = 0;
    public int currentHealth;
    public int maxHealth = 0;

    public void IncrementCount(Collectible collectible, int amount)
    {
        //this segment handles the differentiation of how hearts and coins are treated through the use of their separate classes
        switch (collectible)
        {
            //edge case is to implement my max amount of hearts....
            case HeartTest test:
                GainHealth(amount);
                break;
            //edge case is to implement my max amount of hearts....
            case CoinTest test2:
                GainCoin(amount);
                WinFunction();
                break;
        }
    }
    
    public void GainCoin(int coingain)
    {
        CurrentCoins = Mathf.Clamp(CurrentCoins + coingain, 0, MaxCoins);
    }

    public void LooseCoin(int coinloss)
    {
        CurrentCoins = Mathf.Clamp(CurrentCoins - coinloss, 0, MaxCoins);
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage Taken");
        PlayerDeath();
    }

    public void GainHealth(int healthBoost)
    {
        currentHealth += healthBoost;
    }
    
    
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
    
    public void PlayerDeath()
        //if the player looses all of their hearts then they die
    {
        if (currentHealth <= minHealth)
        {
            RespawnFunction();
        }
    }

    public void WinFunction()
    //if the player collects the max amount of coins in the level then they win
    {
        if (CurrentCoins != MaxCoins) return;
    }

    public void RespawnFunction()
    {
        SceneManager.LoadScene(SceneName);
    }
    
    void Start()
    //significant when the player wants to replay the game or dies and tries again
    {
        ResetHealth();
    } 
    
}
