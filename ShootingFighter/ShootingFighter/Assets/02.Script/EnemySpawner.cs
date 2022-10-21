using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnTime;
    private float _timer;
    private BoxCollider _bound;

    private float _minX, _maxX, _minZ, _maxZ;

    private void Awake()
    {
        _bound = gameObject.GetComponent<BoxCollider>();

        _minX = _bound.transform.position.x - _bound.size.x / 2.0f;
        _maxX = _bound.transform.position.x + _bound.size.x / 2.0f;
        _minZ = _bound.transform.position.z - _bound.size.z / 2.0f;
        _maxZ = _bound.transform.position.z + _bound.size.z / 2.0f;
    }

    private void Update()
    {
        if(_timer < 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(_minX,_maxX),
                                           0.0f,
                                          Random.Range(_minX,_maxX));
            Instantiate(_enemyPrefab,spawnPos,Quaternion.identity);
            _timer = _spawnTime;
        }

        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
