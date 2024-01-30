using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _GameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 spawnPos = new Vector3(0, 1);
        Instantiate(_GameOver, spawnPos, Quaternion.identity);

        Time.timeScale = 0;
    }
}
