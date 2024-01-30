using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    private SpriteRenderer Ground;
    private float Width;

    // Start is called before the first frame update
    void Start()
    {
        Ground = GetComponent<SpriteRenderer>();
        Width = Ground.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ground.transform.position.x < -(Width/4))
        {
            Ground.transform.position = new Vector2(Ground.transform.position.x + Width/4, Ground.transform.position.y);
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
