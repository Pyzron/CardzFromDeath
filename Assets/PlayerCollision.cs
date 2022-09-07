using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Vector3 ogPos;
    Vector3 pos;
    [SerializeField] Transform portal1;
    [SerializeField] Transform portal2;
    // Start is called before the first frame update
    void Start()
    {
        ogPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("DeathZone"))
        {
            transform.position = ogPos;
        }
        if(other.CompareTag("Portal1"))
        {
            transform.position = new Vector3(portal2.transform.position.x - 1.1f, portal2.transform.position.y );
        }
        if(other.CompareTag("Portal2"))
        {
            transform.position = new Vector3(portal1.transform.position.x + 1.1f, portal1.transform.position.y );
        }
    }
}
