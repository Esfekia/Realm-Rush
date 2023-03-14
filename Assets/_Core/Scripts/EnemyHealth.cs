using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitpoints = 5;
    int currentHitpoints = 0;
    int damage = 1;
    Enemy enemy;

    void OnEnable()
    {
        currentHitpoints = maxHitpoints;
    }

    // Start is called before the first frame update
    void Start()    {
        
        enemy = GetComponent<Enemy>();
    }


    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }
    
    void ProcessHit()
    {
        currentHitpoints -= damage;
        if (currentHitpoints <= 0) 
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
