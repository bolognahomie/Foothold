using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] int maxHitPoints = 5;
  [SerializeField] int difficultyRamp = 1;
  [SerializeField] GameObject deathVFX;

  Enemy enemy;

  int currentHitPoints = 0;

  void Start()
  {
    enemy = GetComponent<Enemy>();
  }

  // Start is called before the first frame update
  void OnEnable()
  {
    currentHitPoints = maxHitPoints;
  }

  void OnParticleCollision(GameObject other)
  {
    ProcessHit();
  }

  void ProcessHit()
  {
    currentHitPoints--;
    if (currentHitPoints <= 0)
    {
      // destroy enemy
      KillEnemy();
    }
  }

  void KillEnemy()
  {
    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
    gameObject.SetActive(false);
    maxHitPoints += difficultyRamp;
    enemy.RewardGold();
  }
}
