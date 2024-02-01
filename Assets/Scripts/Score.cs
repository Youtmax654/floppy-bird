using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] TextMeshProUGUI _currentScoreText;
    [SerializeField] TextMeshProUGUI _highScoreText;
    [SerializeField] TextMeshProUGUI _goldenAppleText;
    
    public AudioSource scoreAudio;
    private int _score;
    private int _goldenApple;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentScoreText.text = _score.ToString();

        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighScore()
    {
        if(_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        scoreAudio.Play();
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }

    public void AddGoldenApple()
    {
        if (_goldenApple < 3)
        {
            _goldenApple++;
            _goldenAppleText.text = _goldenApple.ToString();
        }
    }

    public bool UseGoldenApple()
    {
        if (_goldenApple > 0)
        {
            _goldenApple--;
            _goldenAppleText.text = _goldenApple.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetGoldenApple()
    {
        return _goldenApple;
    }
}
