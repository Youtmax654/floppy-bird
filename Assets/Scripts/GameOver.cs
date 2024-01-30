using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _GameOver;
    [SerializeField] private GameObject _RestartBtn;

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
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Time.timeScale = 0;

            Instantiate(_GameOver, _GameOver.transform.position, Quaternion.identity);
            Instantiate(_RestartBtn, _RestartBtn.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Time.timeScale = 0;

            Instantiate(_GameOver, _GameOver.transform.position, Quaternion.identity);
            Instantiate(_RestartBtn, _RestartBtn.transform.position, Quaternion.identity);
        }
    }
}
