using System;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float _powerupFallSpeed = 2f; //Adjustable in inspector for designer

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;

    public GameObject _ball;

    private void Awake()
    {
        //Cache
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _rigidbody2D.velocity = new Vector2(0, -_powerupFallSpeed);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupMultiball(collision); //Activate the powerup

        if (collision.transform.name == "Player") //If the powerup hits the player
        {
            Destroy(gameObject); //Delete the powerup
        }
    }

    private void PowerupMultiball(Collider2D collision)
    {
        var Player = collision.GetComponent<Player>(); //Make sure the collision is the player

        if (Player == null)
            return;

        Instantiate(_ball, transform.position, Quaternion.identity); //Spawn a new ball
        GameSystems.ChangeBallCount(1); //Add to the ball count in GameSystems, only last ball lost subtracts a life
    }
}
