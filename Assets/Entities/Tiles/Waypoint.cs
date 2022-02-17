using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  [SerializeField] bool isPlaceable;
  [SerializeField] Tower towerPrefab;
  public bool IsPlaceable { get { return isPlaceable; } }

  void OnMouseOver()
  {
    if (isPlaceable)
    {
      transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
      Debug.Log(transform.name);
    }
  }

  void OnMouseExit()
  {
    transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
  }

  void OnMouseDown()
  {
    if (isPlaceable)
    {
      bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
      isPlaceable = !isPlaced;
    }
  }
}
