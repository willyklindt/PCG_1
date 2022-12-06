using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    public float speed = 10f;

    public Rigidbody2D rb;

    Vector2 movement; //stores X & Y-value


    // Update is called once per frame
    void Update() //input
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() //executed on a fixed time -- movement
    {
        //rb = variable for player. currentposition + new movment x & y * speed
          rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
