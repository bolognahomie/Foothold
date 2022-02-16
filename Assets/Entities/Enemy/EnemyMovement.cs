using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  [SerializeField] List<Waypoint> path = new List<Waypoint>();
  [SerializeField] float movementSpeed = 1f;

  void Start()
  {
    FindPath();
    ReturnToStart();
    StartCoroutine(FollowPath()); // start coroutine
  }

  void FindPath()
  {
    path.Clear();

    GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

    foreach(GameObject waypoint in waypoints)
    {
      path.Add(waypoint.GetComponent<Waypoint>());
    }
  }

  void ReturnToStart()
  {
    transform.position = path[0].transform.position;
  }

  IEnumerator FollowPath()
  {
    foreach (Waypoint waypoint in path) // for loop for each tile in the path, waypoint = the tile we are currently moving to
    {
      Vector3 startPosition = transform.position; // identify start tile, tile our entity is currently on
      Vector3 endPosition = waypoint.transform.position; // identify end tile, tile we want to move our entity to next
      float travelPercent = 0f;

      transform.LookAt(endPosition); // makes object point towards next tile which keeps our entity pointing the correct way

      while (travelPercent < 1) // while the travel percent is less than 1, i.e. not yet at the end tile (Travel percent is the percent currently traveled between the start and end tiles, 0-1)
      {
        travelPercent += Time.deltaTime * movementSpeed; // update travelpercent with time.deltaTime multiplied by our movement speed
        transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent); // moves entity towards next tile
        yield return new WaitForEndOfFrame(); // yeild back until the end of the current frame
      }
    }

    Destroy(gameObject);
  }
}
