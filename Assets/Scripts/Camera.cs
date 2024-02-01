using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public static GameCamera instance;

    [SerializeField] private float _shakeDuration = 5f;
    [SerializeField] private Camera _camera;

    private float _time;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateCamera()
    {
        _camera.transform.Rotate(0, 0, 180);
    }

    public void MirrorCamera()
    {
        _camera.transform.Rotate(0, 180, 0);
    }
}
