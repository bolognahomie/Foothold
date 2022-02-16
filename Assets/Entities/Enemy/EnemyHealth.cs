using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] int maxHitPoints = 5;
  [SerializeField] GameObject deathVFX;
  int currentHitPoints = 0;

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
      DestroyEnemy();
    }
  }

  void DestroyEnemy()
  {
    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
    gameObject.SetActive(false);
  }
}
