using System;
using UnityEngine;

public class Hazard : MonoBehaviour
{
   [SerializeField] private int EnemyDamage = 5;

   public GameManager gameManager;

   public void OnTriggerEnter2D(Collider2D other)
   {
      gameManager.LooseCoin(EnemyDamage);
      gameManager.TakeDamage(EnemyDamage);
   }

   void Start()
   {
      gameManager = FindFirstObjectByType<GameManager>();
   }
}
