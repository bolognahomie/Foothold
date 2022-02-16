using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  [SerializeField] List<Waypoint> path = new List<Waypoint>();
  [SerializeField] float waitTime = 1f;

  void Start()
  {
    StartCoroutine(FollowPath()); // start coroutine
  }

  IEnumerator FollowPath()
  {
    foreach (Waypoint waypoint in path) // for loop for each tile in the path, waypoint = the tile we are currently moving to
    {
      Vector3 startPosition = transform.position; // identify start tile, tile our entity is currently on
      Vector3 endPosition = waypoint.transform.position; // identify end tile, tile we want to move our entity to next
      float travelPercent = 0f;

      while (travelPercent < 1) // while the travel percent is less than 1, i.e. not yet at the end tile (Travel percent is the percent currently traveled between the start and end tiles, 0-1)
      {
        travelPercent += Time.deltaTime; // update travelpercent with time.deltaTime
        transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent); // moves entity towards next tile
        yield return new WaitForEndOfFrame(); // yeild back until the end of the current frame
      }
    }
  }
}
