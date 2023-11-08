using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public float movementSpeed;
    private float inputHorizontal, inputVertical;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        setGmPlayerPositions();
    }

    private void move()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        player.velocity = new Vector2(movementSpeed * inputHorizontal, movementSpeed * inputVertical); ;


    }

    private void setGmPlayerPositions()
    {
        GameManager.setPlayerPosX(transform.position.x);
        GameManager.setPlayerPosY(transform.position.y);
    }
}
