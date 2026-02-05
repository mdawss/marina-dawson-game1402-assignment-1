using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    
    public List<GameObject> HeartsUI = new List<GameObject>(); //quite literally the most important part of the script
    public GameObject HeartPrefab; //prefabs to be spawned within the list
    public GameObject heartSpawner; //destination where the hearts will be spawned
    public TMP_Text ScoreText; //the text that reflects the amount of coins picked up
    
    public string SceneName; //variable for the scene
    
    public GameManager gameManager; //calls the game manager
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneName); //loads the level 1 scene
    }
    

    public void IncrementHeartSprite(int amount)
    {
        for (int i = 0; i < amount; i++) 
        {
            var heart = Instantiate(HeartPrefab, heartSpawner.transform.position, Quaternion.identity); //places the hearts onscreeen at the heart spawner location
            //heart.transform.parent = heartSpawner.transform; //spawner now takes ownership of the hearts
            heart.transform.SetParent(heartSpawner.transform); //spawner now takes ownership of the hearts
            HeartsUI.Add(heart); //the heart added to the amount
            Debug.Log("Heart Incremented");
        }
    }

    public void DecrementHeartSprite(int amount)
    {
        //if the amount of damage that the player takes is more than the player health amount then it sets the damage to whatever the current health is.
        if (amount > gameManager.currentHealth)
        {
            amount = gameManager.currentHealth;
        }
        for (int i = 0; i < amount; i++)
        {
            var lastHeart = HeartsUI[i%HeartsUI.Count] ; //modulus to prevent going out of bounds compare against count in list of hearts
            Destroy(lastHeart); //the placement of the hearts onscreen
            HeartsUI.RemoveAt(i%HeartsUI.Count); 
            Debug.Log("Heart decremented");
        }
    }

    public void IncrementScore(int amount)
    {
        ScoreText.text = amount.ToString(); //reflects the score amount and turns it to a string onscreen
    }

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); //reference to game manager
    }
}
