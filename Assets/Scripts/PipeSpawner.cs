using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;

    private float _timer;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = new Vector3(-2, Random.Range(-_heightRange, _heightRange));
        Debug.Log(spawnPos.y);

        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
