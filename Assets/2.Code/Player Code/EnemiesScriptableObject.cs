using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Create Enemies")]
public class EnemiesScriptableObject : ScriptableObject
{
    [SerializeField, Range(0,100000), InspectorName("HP"), Tooltip("Enemy Health")] private int _healthPoints;
    [SerializeField, Range(0,999), InspectorName("Attack Damage"), Tooltip("Enemy Attack Damage")] private int _attackDamage;
    [SerializeField, Range(0,25), InspectorName("Enemy Speed"), Tooltip("Enemy Speed ")] private float _speed;
    [SerializeField, InspectorName("Has Shield?"), Tooltip("Determines if the enemy has a shield")] private bool _hasShield;
    [SerializeField, InspectorName("Death Animation")] private GameObject _pfDeathAnim;
    [SerializeField, InspectorName("Death Animation")] private Sprite _enemySprite;
    public enum enemyType{Mob, MiniBoss, Boss, SecretBoss};
    [SerializeField, InspectorName("Enemy Type"), Tooltip("Type of the enemy")] private enemyType types;

    #region GetterAndSetters
    public int HealthPoints { get => _healthPoints;}
    public int AttackDamage { get => _attackDamage; }
    public float Speed { get => _speed;  }
    public bool HasShield { get => _hasShield;  }
    public GameObject PfDeathAnim { get => _pfDeathAnim;  }
    public enemyType EnemyType { get => types;  }

    public Sprite EnemySprite { get => _enemySprite; }
    #endregion GetterAndSetters

}