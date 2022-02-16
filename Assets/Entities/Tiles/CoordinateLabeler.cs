using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
  [SerializeField] Color defaultColor = new Color32(250, 191, 13, 255);
  [SerializeField] Color blockedColor = Color.gray;


  TextMeshPro label;
  Vector2Int coordinates = new Vector2Int();
  Waypoint waypoint;

  void Awake()
  {
    label = GetComponent<TextMeshPro>();
    label.enabled = false;

    waypoint = GetComponentInParent<Waypoint>();
    DisplayCoordinates();
  }

  void Update()
  {
    if (!Application.isPlaying)
    {
      // do something only if application is not playing
      DisplayCoordinates();
      UpdateObjectName();
    }

    ColorCoordinates();
    toggleLabels();
  }

  void toggleLabels()
  {
    if (Input.GetKeyDown(KeyCode.C))
    {
      label.enabled = !label.IsActive();
    }
  }

  void ColorCoordinates()
  {
    if (waypoint.IsPlaceable)
    {
      label.color = defaultColor;
    }
    else
    {
      label.color = blockedColor;
    }
  }

  void DisplayCoordinates()
  {
    coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
    coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

    label.text = $"{coordinates.x}, {coordinates.y}";
  }

  void UpdateObjectName()
  {
    transform.parent.name = $"Tile {coordinates.ToString()}";
  }
}
