using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitpoints = 5;
    [Tooltip("Ads amount to max hitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
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
            maxHitpoints += difficultyRamp;
            enemy.RewardGold();
            
        }
    }
}
