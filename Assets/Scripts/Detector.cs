using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour
{
    [SerializeField] private Canvas _GameOver;
    [SerializeField] private RuntimeAnimatorController _redFlap;
    [SerializeField] private RuntimeAnimatorController _yellowFlap;

    private float _cherriesTimer;
    private bool _cherriesActive = false;
    public int _score;
    public AudioSource gameOverAudio;
    public AudioSource AudioSwoosh;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_cherriesActive)
        {
            if (_cherriesTimer > 5f)
            {
                _cherriesActive = false;
                _cherriesTimer = 0;

                FlyBehavior playerScript = FindObjectOfType<FlyBehavior>();
                playerScript._velocity = playerScript._velocity / 1.35f;
                FlyBehavior playerSkin = FindObjectOfType<FlyBehavior>();
                playerSkin.GetComponent<Animator>().runtimeAnimatorController = _yellowFlap;

            }

            _cherriesTimer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Time.timeScale = 0;

            Instantiate(_GameOver, _GameOver.transform.position, Quaternion.identity);

            gameOverAudio.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            if (Score.instance.UseGoldenApple() == false)
            {
                Time.timeScale = 0;

                Instantiate(_GameOver, _GameOver.transform.position, Quaternion.identity);

                gameOverAudio.Play();
            }
            else
            {
                AudioSwoosh.Play();
            }
        }
        if (collision.gameObject.CompareTag("Detector"))
        {
            Score.instance.UpdateScore();
        }
        if (collision.gameObject.CompareTag("Golden Apple"))
        {
            int numberOfGApple = Score.instance.GetGoldenApple();
            if (numberOfGApple < 3) 
            {
                Destroy(GameObject.FindGameObjectWithTag("Golden Apple"));
                Score.instance.AddGoldenApple();
            }
        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Banana"));
            GameCamera.instance.RotateCamera();
            AudioSwoosh.Play();
        }
        if (collision.gameObject.CompareTag("Cherries"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Cherries"));
            // Malus (Saut * 1.5)
            FlyBehavior playerScript = FindObjectOfType<FlyBehavior>();
            playerScript._velocity = playerScript._velocity * 1.35f;
            _cherriesActive = true;

            // Changer le Skin --> Red
            FlyBehavior playerSkin = FindObjectOfType<FlyBehavior>();
            playerSkin.GetComponent<Animator>().runtimeAnimatorController = _redFlap;

            AudioSwoosh.Play();
        }
    }
}