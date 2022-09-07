using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorActivator : MonoBehaviour
{
    [SerializeField] Animator _myAnim;
    public bool doorActivated {get; private set;}
    [SerializeField] GameObject [] c;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        c = GameObject.FindGameObjectsWithTag("Activators");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // var c = GameObject.FindGameObjectsWithTag("Player");
        
            if(other.CompareTag("Activators") )
            {
                Debug.Log("Abriendo...");
                _myAnim.SetBool("OpenDoor", true);
                doorActivated = true;
            }
        
       
    }
}
