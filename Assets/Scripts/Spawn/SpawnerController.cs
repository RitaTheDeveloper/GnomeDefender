using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private int _maxNumberOfEnemies;
    [SerializeField] private List<SpawnUnit> _listOfEnemySpawners;

    private GameManager _gameManager;

    private int _totalAmountOfEnemies;
    public int MaxNumberOfEnemies { get => _maxNumberOfEnemies; }
    public int TotalAmountOfEnemies { get => _totalAmountOfEnemies; }
    public GameObject TargetTown { get; private set; }
    public GameObject TargetPlayer { get; private set; }

    private void Start()
    {
        _totalAmountOfEnemies = 0;
    }

    public void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
        TargetPlayer = _gameManager.Player;
        TargetTown = _gameManager.Town;

        foreach (var spawner in _listOfEnemySpawners)
        {
            spawner.gameObject.SetActive(true);
            spawner.Init(this);
        }
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

    public GameObject GetTarget(TargetForEnemyType targetType)
    {
        GameObject target = null;

        switch (targetType)
        {
            case TargetForEnemyType.Town:
                target = TargetTown;
                break;

            case TargetForEnemyType.Player:
                target = TargetPlayer;
                break;
            default:
                break;
        }

        return target;
    }

    public GameObject GetSpawnPoint(SpawnPointType spawnType)
    {
        GameObject point = null;

        switch (spawnType)
        {
            case SpawnPointType.Town:
                point = TargetTown;
                break;

            case SpawnPointType.Player:
                point = TargetPlayer;
                break;
            default:
                break;
        }

        return point;
    }
}
