using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] EnemiesScriptableObject enemyData;
    void Start()
    {
        StartCoroutine(Attack1());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Attack1()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log(enemyData.Speed);
        #region cosas
        // if(enemyData.EnemyType is EnemiesScriptableObject.enemyType.MiniBoss)
        // {
            // Debug.Log("Alongas Minibongs" + transform.position.ToString());
        // }
        // if(enemyData.EnemyType is EnemiesScriptableObject.enemyType.Mob)
        // {
            // Debug.Log("Alongas Mongbs"+ transform.position.ToString());
        // }
        #endregion cosas
    }
}
