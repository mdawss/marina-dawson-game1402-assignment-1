using System;
using System.Collections;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   public GameObject CollectiblePrefab;
   
   
   public AudioManager audioManager;
   public PlayerManager playerManager;
   
   [SerializeField] protected AudioClip _pickupSound;
   [SerializeField] protected int _pickupAmount = 1;
   
   //effects for pickup
   [SerializeField] private SpriteRenderer _spriteRenderer;
   private ParticleSystem _particleSystem;
   [SerializeField] private float _secondsToWait = 0.2f;
   

   public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.GetComponent<PlayerControllerExample>())
       {
           
           AddToInventory();
       }
   }

   public virtual void AddToInventory()
    {
        if(_pickupSound != null)
        {
            audioManager.PlaySound(_pickupSound);
        }
        playerManager.IncrementCount(this,_pickupAmount);
        StartCoroutine(FlashAndDestroy());
    }

    private IEnumerator FlashAndDestroy()
    {
        Color previousColor = _spriteRenderer.color;
        
        //create a variable to be able to change the colors of the particles
        var main = _particleSystem.main;
        main.startColor = previousColor;
        _particleSystem.Play();
        _spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(_secondsToWait);
        _spriteRenderer.color = previousColor;
        yield return new WaitForSeconds(_secondsToWait);
        _spriteRenderer.color = Color.white;
        Destroy(gameObject);
    }
    
   
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        playerManager = FindFirstObjectByType<PlayerManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
