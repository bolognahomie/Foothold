using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
  [SerializeField] Transform weapon;
  [SerializeField] ParticleSystem projectileParticles;
  [SerializeField] float range = 15f;
  Transform target;

  void Update()
  {
    FindClosestTarget(); // find closest enemy target
    AimWeapon();
  }

  void FindClosestTarget()
  {
    Enemy[] enemies = FindObjectsOfType<Enemy>(); // gets all enemies and stores them in an array
    Transform closestTarget = null;
    float maxDistance = Mathf.Infinity;

    foreach (Enemy enemy in enemies) // loops through all enemies on the board
    {
      float targetDistance = Vector3.Distance(transform.position, enemy.transform.position); // gets the distance between the weapon and current enemy

      if (targetDistance < maxDistance) // checks to see if current enemy is closer than the current closest enemy
      {
        closestTarget = enemy.transform; // if TRUE, we set the closest enemy to this enemy
        maxDistance = targetDistance; // if TRUE we set out maxdistance to the distance of this enemy, so that we can see if the next enemy is closer.
      }
    }
    target = closestTarget; // set closest enemy as our target
  }

  void AimWeapon()
  {
    float targetDistance = Vector3.Distance(transform.position, target.position);

    weapon.LookAt(target);

    if (targetDistance < range)
    {
        Attack(true);
    }
    else
    {
        Attack(false);
    }
  }

  void Attack(bool isShooting)
  {
    var emissionModule = projectileParticles.emission;
    emissionModule.enabled = isShooting;
  }
}
