using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Resourse _resource;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        var waitForSeconds = new WaitForSeconds(_timeBetweenSpawn);

        while (true)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            _spawnPoints[spawnPointNumber].transform.position = new Vector3(Random.Range(5.0f, 15.0f), 0.5f, Random.Range(5.0f, 15.0f));

            Resourse resource = Instantiate(_resource, _spawnPoints[spawnPointNumber].transform.position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
