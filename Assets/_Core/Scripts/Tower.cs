using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;
    [SerializeField] int towerBuildDelay = 2;
    
    
    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);  
        }
        StartCoroutine(Build());
    }
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindAnyObjectByType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= towerCost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
        }

        return false;

    }
    IEnumerator Build()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(towerBuildDelay);
        }
    }    

}
