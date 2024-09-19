using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private int _maxNumberOfEnemies;

    private int _totalAmountOfEnemies;
    public int MaxNumberOfEnemies { get => _maxNumberOfEnemies; }
    public int TotalAmountOfEnemies { get => _totalAmountOfEnemies; }

    private void Start()
    {
        _totalAmountOfEnemies = 0;
    }

    public void IncreaseCounterOfEnemies(int amount)
    {
        _totalAmountOfEnemies += amount;
    }

    public bool CanSpawn()
    {
        bool canSpawn = true;

        if (_totalAmountOfEnemies >= _maxNumberOfEnemies)
        {
            canSpawn = false;
        }
        
        return canSpawn;
    }
}
