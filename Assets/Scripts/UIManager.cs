using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public List<GameObject> HeartsUI = new List<GameObject>();
    public GameObject HeartPrefab;
    public GameObject heartSpawner;
    public TMP_Text ScoreText;
    
    public string SceneName;
    
    public GameManager gameManager;
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneName);
    }
    

    public void IncrementHeartSprite(int amount)
    {
        for (int i = 0; i < amount; i++) 
        {
            var heart = Instantiate(HeartPrefab, heartSpawner.transform.position, Quaternion.identity);
            heart.transform.parent = heartSpawner.transform;
            HeartsUI.Add(heart);
            Debug.Log(HeartsUI);
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
            var lastHeart = HeartsUI[i%HeartsUI.Count] ; //modulus to prevent going out of bounds compare against count in list of heartss
            Destroy(lastHeart);
            HeartsUI.RemoveAt(i%HeartsUI.Count);
            Debug.Log(HeartsUI);
        }
    }

    public void IncrementScore(int amount)
    {
        ScoreText.text = amount.ToString();
    }

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
}
