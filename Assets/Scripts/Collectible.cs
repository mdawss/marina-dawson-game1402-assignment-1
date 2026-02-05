using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// this script handles the obverall logic for what happens when a collectible is collided with visuals and audio, it also communicates with the GameManager 
/// </summary>
public class Collectible : MonoBehaviour
{
    public GameObject CollectiblePrefab;
    
    //calls to other needed scripts
    public AudioManager audioManager;
    public GameManager gameManager;
    
    [SerializeField] protected AudioClip _pickupSound; //the pickup sound called when added to inventory
    [SerializeField] protected int _pickupAmount = 1; //amount of collectible when picked up

    //effects for pickup
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private ParticleSystem _particleSystem;
    [SerializeField] private float _secondsToWait = 0.2f;


    public void OnTriggerEnter2D(Collider2D other) //checks the collision
    {
        if (other.GetComponent<PlayerControllerExample>())
        {
            AddToInventory(); //calls the add to inventory function
        }
    }

    public virtual void AddToInventory()
    {
        if (_pickupSound != null) 
        {
            audioManager.PlaySound(_pickupSound); //plays the sound for the collectible 
        }
        gameManager.IncrementCount(this, _pickupAmount); //increments the count of the collectible from the GameManager
        StartCoroutine(FlashAndDestroy()); //then triggers the particle system
    }
    

    private IEnumerator FlashAndDestroy()
    {
        //the coroutine for the particle system when the collectible is collided with 
        Color previousColor = _spriteRenderer.color;
        var main = _particleSystem.main;//created a variable to be able to change the colors of the particles
        main.startColor = previousColor;
        _particleSystem.Play();//play the particle system]
        _spriteRenderer.color = Color.white; //the particles will come out as white
        yield return new WaitForSeconds(_secondsToWait); //waits for X seconds
        _spriteRenderer.color = previousColor; //particles come out as the previous color of the actual particle
        yield return new WaitForSeconds(_secondsToWait); //waits another X seconds
        _spriteRenderer.color = Color.white; //turns back to white particles 
        
        //the actual particle system happens incredibly quicly but its satisfying when it looks like the same colour because it looks like the collectible explodes
        Destroy(gameObject);
    }

    void Start()
    {
        //finds all needed references
        audioManager = FindFirstObjectByType<AudioManager>();
        gameManager = FindFirstObjectByType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

}   