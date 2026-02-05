using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string SceneName; //to keep track of what scene we are in, start scene or level scene 
    
    public int CurrentCoins; //varibale to keep track of current coins
    public int MaxCoins; //variable to set the win condition
    
    public int minHealth = 0; //varibale to make sure than health does not go into the negatives
    public int currentHealth; //varibale to track the current health
    public int maxHealth = 0; //varibale to set the loose condition

    public GameObject PauseMenu; //pause menu canvas that will either be enabled or disabled with bool
    public bool ispaused; //>>the bool in question 
    
    public UIManager uiManager; //calls on UIManager script

    public void IncrementCount(Collectible collectible, int amount)
    {
        //this segment handles the differentiation of how hearts and coins are treated through the use of their separate classes comparing tags is not nececary here
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
    
    public void GainCoin(int coingain) //function for when a coin is gained
    {
        CurrentCoins = Mathf.Clamp(CurrentCoins + coingain, 0, MaxCoins); //clamp is essential so there can be hard boundaries on the amount of coins gained 0.
        uiManager.IncrementScore(CurrentCoins); //UI manager will turn this into visual feedback
    }

    public void LooseCoin(int coinloss) //function when a coin is lost
    {
        CurrentCoins = Mathf.Clamp(CurrentCoins - coinloss, 0, MaxCoins); //clamp is essential so there cannot be negative coin loss. 
        uiManager.IncrementScore(CurrentCoins); 
    }
    
    public void TakeDamage(int damage) 
    {
        uiManager.DecrementHeartSprite(damage); //UI manager will decrement the amount of hearts on screen
        currentHealth -= damage; //-damage to the current health
        Debug.Log("Damage Taken");
        PlayerDeath(); //will reload the Main Menu
    }

    public void GainHealth(int healthBoost)
    {
        uiManager.IncrementHeartSprite(healthBoost); //UI manager will decrement the amount of hearts on screen
        currentHealth += healthBoost;
    }
    
    
    public void ResetHealth()
    {
        currentHealth = maxHealth; //if the player dies then they need to reset the player health and the UI to reflect a reset game
        uiManager.IncrementHeartSprite(currentHealth);
    }
    
    public void PlayerDeath()
        
        //if the player looses all of their hearts then they die
    {
        if (currentHealth <= minHealth)
        {
            RespawnFunction(); //will take them to the main menu
        }
    }

    public void WinFunction()
    //if the player collects the max amount of coins in the level then they win
    {
        if (CurrentCoins != MaxCoins) return; 
        SceneManager.LoadScene(SceneName); //goes to the main menu
    }

    public void RespawnFunction()
    {
        SceneManager.LoadScene(SceneName); //goes to the main menu also
    }

    public void Pause()
    {
        if (ispaused) 
        {
            ispaused = false;
            Time.timeScale = 1;
            PauseMenu.SetActive(false); //makes sure that the pause menu doesn't sit over the screen despite gameplay continuing
        }
        else
        {
            ispaused = true;
            Time.timeScale = 0; //most importnant part here is the time scale!!!!!
            PauseMenu.SetActive(true); //enables the pause menu screen to overlay
        }
    }
    
    void Start()
    //significant when the player wants to replay the game or dies and tries again
    {
        ResetHealth();
        uiManager = FindFirstObjectByType<UIManager>(); //finds necessary references
    } 
    
}
