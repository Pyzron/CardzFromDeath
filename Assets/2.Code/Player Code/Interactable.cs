using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Doors") && Input.GetAxisRaw("Vertical")>0.1f)
        {
            Debug.Log("Accediendo");
        }
    }

}
