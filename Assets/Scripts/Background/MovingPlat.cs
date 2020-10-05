using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public float speed;
    public float changeDirection = -1;
    Vector3 Move;
    void Start()
    {
         Move = this.transform.position;
    }
    void Update()
    {
        Move.x += speed;
        this.transform.position = Move;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}
