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
    [SerializeField] private float _radiusOfTown;
    [SerializeField] private TargetForEnemyType _spawnFromTypeTarget;
    private Transform _target;

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
        if (_target)
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
        _target = _spawnerController.GetTarget(_spawnFromTypeTarget).transform;
    }

    private IEnumerator SpawnOneUnit()
    {
        while (_target && _spawnerController.CanSpawn() && _timerForStopSpawn < _endSpawnTime)
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
        if (_target)
        {
            Vector3 pos = new Vector3(Random.Range(-_radiusOfTown, _radiusOfTown), Random.Range(-_radiusOfTown, _radiusOfTown), 0f);
            _spawnPosition = _target.position + pos;
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
