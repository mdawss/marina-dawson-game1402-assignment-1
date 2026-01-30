using System;
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

    public GameObject PauseMenu;

    public bool ispaused;
    
    public UIManager uiManager;

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
        uiManager.IncrementScore(CurrentCoins);
    }

    public void LooseCoin(int coinloss)
    {
        CurrentCoins = Mathf.Clamp(CurrentCoins - coinloss, 0, MaxCoins);
        uiManager.IncrementScore(CurrentCoins);
    }
    
    public void TakeDamage(int damage)
    {
        uiManager.DecrementHeartSprite(damage);
        currentHealth -= damage;
        Debug.Log("Damage Taken");
        PlayerDeath();
    }

    public void GainHealth(int healthBoost)
    {
        uiManager.IncrementHeartSprite(healthBoost);
        currentHealth += healthBoost;
    }
    
    
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        uiManager.IncrementHeartSprite(currentHealth);
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
        SceneManager.LoadScene(SceneName);
    }

    public void RespawnFunction()
    {
        SceneManager.LoadScene(SceneName);
    }


    public void Pause()
    {
        if (ispaused) 
        {
            ispaused = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
        else
        {
            ispaused = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }

    private void Update()
    {
        
    }

    void Start()
    //significant when the player wants to replay the game or dies and tries again
    {
        ResetHealth();
        uiManager = FindFirstObjectByType<UIManager>();
    } 
    
}
