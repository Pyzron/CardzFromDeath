using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour, IDamage
{
    [SerializeField] EnemiesScriptableObject data;

    private int _maxHealth;
    private int _currentHealth;
    private int _incomingDamage;
    private bool _shield;
    // Start is called before the first frame update
    void Start()
    {
        _maxHealth = data.HealthPoints;
        _currentHealth = _maxHealth;

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
        if(other.CompareTag("Weapon"))
        {
            ReceiveDamage();
        }
    }
    public void DealDamage()
    {
    }
    public void ReceiveDamage()
    {
        _currentHealth = _currentHealth - _incomingDamage;
    }
}
