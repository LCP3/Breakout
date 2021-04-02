using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    private Vector3 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        GameSystems.Lives = 3; //Set up lives -- Want to refactor this line and add adjustable # to inspector
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y); //Set the position of the mouse in the game
        _rigidbody2D.position = _mousePosition; //Set the player's position to the mouse
    }

}