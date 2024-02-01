using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 2.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipe;
    [SerializeField] private GameObject _goldenApple;
    [SerializeField] private GameObject _banana;
    [SerializeField] private GameObject _cherries;

    private float _timer;
    public Vector3 spawnPos;
    private int random;
    private int Element;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFruit();
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnFruit();
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        spawnPos = new Vector3(-2, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }

    private void SpawnFruit()
    {
        random = Random.Range(1, 5);
        if (random == 1)
        {
            Element = Random.Range(1, 4);
            switch (Element)
            {
                case 1:
                    spawnPos = new Vector3(2, Random.Range(-_heightRange, _heightRange));
                    GameObject goldenApple = Instantiate(_goldenApple, spawnPos, Quaternion.identity);
                    Destroy(goldenApple, 10f);
                    break;
                case 2:
                    spawnPos = new Vector3(2, Random.Range(-_heightRange, _heightRange));
                    GameObject banana = Instantiate(_banana, spawnPos, Quaternion.identity);
                    Destroy(banana, 10f);
                    break;
                case 3:
                    spawnPos = new Vector3(2, Random.Range(-_heightRange, _heightRange));
                    GameObject cherries = Instantiate(_cherries, spawnPos, Quaternion.identity);
                    Destroy(cherries, 10f);
                    break;
            }
        }
    }
}
