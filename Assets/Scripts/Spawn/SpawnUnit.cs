using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private Transform _unitTransform;
    [SerializeField] private float _startSpawnTime = 1f;
    [SerializeField] private float _endSpawnTime = 10f;
    [SerializeField] private float _cd;
    [SerializeField] private float _radiusOfSpawnPoint;
    [SerializeField] private SpawnPointType _spawnFromPointType;
    [SerializeField] private Transform _spawnFromPointTransform;
    private Transform _spawnPoint;

    private SpawnerController _spawnerController;

    private Vector3 _spawnPosition;
    private bool _isBeginningOfWave;
    private float _timerForStopSpawn;

    private void Awake()
    {
        _isBeginningOfWave = true;
        _timerForStopSpawn = 0f;
    }

    private void Start()
    {
        if (_spawnPoint)
        {
            SetPosition();
            StartCoroutine(SpawnOneUnit());
        }
    }

    private void FixedUpdate()
    {
        _timerForStopSpawn += Time.fixedDeltaTime;
    }

    public void Init(SpawnerController spawnerController)
    {
        _spawnerController = spawnerController;
        if (_spawnFromPointType == SpawnPointType.Null) { _spawnPoint = _spawnFromPointTransform; }
        else { _spawnPoint = _spawnerController.GetSpawnPoint(_spawnFromPointType).transform; }
    }

    private IEnumerator SpawnOneUnit()
    {
        while (_spawnPoint && _spawnerController.CanSpawn() && _timerForStopSpawn < _endSpawnTime)
        {
            float timeSpawn = SetSpawnTime();
            yield return new WaitForSeconds(timeSpawn);
            SetPosition();
            var unit = Instantiate(_unitPrefab, _unitTransform);
            unit.transform.position = _spawnPosition;
            unit.GetComponent<Unit>().Init(_spawnerController);
            _spawnerController.IncreaseCounterOfEnemies(1);
            _isBeginningOfWave = false;
        }
    }

    private void SetPosition()
    {
        if (_spawnPoint)
        {
            Vector3 pos = new Vector3(Random.Range(-_radiusOfSpawnPoint, _radiusOfSpawnPoint), Random.Range(-_radiusOfSpawnPoint, _radiusOfSpawnPoint), 0f);
            _spawnPosition = _spawnPoint.position + pos;
        }
           
    }

    private float SetSpawnTime()
    {
        if (_isBeginningOfWave)
        {
            return _startSpawnTime;
        }
        else
        {
            //return Random.Range(_minSpawnTime, _maxSpawnTime);
            return _cd;
        }
    }
}
