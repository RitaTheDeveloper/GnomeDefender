using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private Transform _unitTransform;
    [SerializeField] private float _cd;
    [SerializeField] private float _radiusOfTown;
    [SerializeField] private Transform _target;
    [SerializeField] private SpawnerController spawnerController;

    private Vector3 _spawnPosition;

    private void Start()
    {
        if (_target)
        {
            SetPosition();
            StartCoroutine(SpawnOneUnit());
        }

    }

    private IEnumerator SpawnOneUnit()
    {
        while (_target && spawnerController.CanSpawn())
        {
            yield return new WaitForSeconds(_cd);
            SetPosition();
            var unit = Instantiate(_unitPrefab, _unitTransform);
            unit.transform.position = _spawnPosition;
            spawnerController.IncreaseCounterOfEnemies(1);
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
}
