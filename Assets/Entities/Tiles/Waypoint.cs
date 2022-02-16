using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  [SerializeField] bool isPlaceable;

  [SerializeField] GameObject towerPrefab;

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
      Instantiate(towerPrefab, transform.position, Quaternion.identity);
      isPlaceable = false;
    }
  }

  //   [SerializeField] float hoverPositionChange = 2f;

  //   Vector3 positionChange = new Vector3(+0f, +.01f, +0f);
  //   Vector3 originalPosition;
  // originalPosition = transform.position;

  // if (transform.position.y < hoverPositionChange)
  // {
  //   transform.position += positionChange;
  // }

  //   IEnumerator ReturnToOriginalPosition()
  //   {
  //     while (transform.position.y > originalPosition.y)
  //     {
  //       transform.position -= positionChange;
  //       yield return new WaitForEndOfFrame();
  //     }
  //   }
}
