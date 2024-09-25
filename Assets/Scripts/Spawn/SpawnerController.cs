using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private int _maxNumberOfEnemies;
    [SerializeField] private List<SpawnUnit> _listOfEnemySpawners;

    private GameManager _gameManager;
    private GameObject _targetTown, _targetPlayer;

    private int _totalAmountOfEnemies;
    public int MaxNumberOfEnemies { get => _maxNumberOfEnemies; }
    public int TotalAmountOfEnemies { get => _totalAmountOfEnemies; }
    public GameObject TargetTown { get => _targetTown; }
    public GameObject TargetPlayer { get => _targetPlayer; }

    private void Start()
    {
        _totalAmountOfEnemies = 0;
    }

    public void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
        _targetPlayer = _gameManager.Player;
        _targetTown = _gameManager.Town;

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
                target = _targetTown;
                break;

            case TargetForEnemyType.Player:
                target = _targetPlayer;
                break;
            default:
                break;
        }

        return target;
    }
}
