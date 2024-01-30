using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Canvas _GameOver;

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
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Time.timeScale = 0;

            Instantiate(_GameOver, _GameOver.transform.position, Quaternion.identity);
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
