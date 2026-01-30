using System;
using UnityEngine;

public class Hazard : MonoBehaviour
{
   [SerializeField] private int EnemyDamage = 5;

   public GameManager gameManager;
   public AudioClip _Hazardsound;
   public AudioManager audioManager;

   public void OnTriggerEnter2D(Collider2D other)
   {
      if(!other.GetComponent<PlayerControllerExample>()) return;
      gameManager.LooseCoin(EnemyDamage);
      gameManager.TakeDamage(EnemyDamage);
      if (audioManager != null && _Hazardsound != null)
      {
         audioManager.PlaySound(_Hazardsound);
      }
   }

   void Start()
   {
      gameManager = FindFirstObjectByType<GameManager>();
      audioManager = FindFirstObjectByType<AudioManager>();
   }
}
