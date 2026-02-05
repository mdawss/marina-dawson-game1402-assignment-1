using System;
using UnityEngine;

public class Hazard : MonoBehaviour
{
   [SerializeField] private int EnemyDamage = 5;

   //scripts to acsess
   public GameManager gameManager; //will use the overall 
   public AudioClip _Hazardsound; //name of the audio clip
   public AudioManager audioManager; 

   public void OnTriggerEnter2D(Collider2D other)
   {
      if(!other.GetComponent<PlayerControllerExample>()) return;
      
      gameManager.LooseCoin(EnemyDamage); //loose a coin when you take enemy damage
      gameManager.TakeDamage(EnemyDamage); //take damage (enemy damage)
      if (audioManager != null && _Hazardsound != null)
      {
         audioManager.PlaySound(_Hazardsound); //plays the hazard sound
      }
   }

   void Start()
   {
      //references needed
      gameManager = FindFirstObjectByType<GameManager>();
      audioManager = FindFirstObjectByType<AudioManager>();
   }
}
