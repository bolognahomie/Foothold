using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // IEnumerator DestroyText()
    // {
    //     while (gameObject.GetComponent<TextMesh>().color.a > 0)
    //     {
    //         newAlpha--;
    //         gameObject.GetComponent<TextMesh>().color = new Color(0, 255, 61, 0);
    //         yield return new WaitForEndOfFrame();
    //     }
    // }
}
