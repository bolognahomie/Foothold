using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] int maxHitPoints = 5;
  [SerializeField] GameObject deathVFX;
  int currentHitPoints = 0;

  // Start is called before the first frame update
  void Start()
  {

  }

  void OnParticleCollision(GameObject other)
  {
    ProcessHit();
  }

  void ProcessHit()
  {
    if (currentHitPoints == maxHitPoints - 1)
    {
      // destroy enemy
      DestroyEnemy();
    }
    else
    {
      currentHitPoints++;
    }
  }

  void DestroyEnemy()
  {
    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }
}
