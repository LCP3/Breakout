using System;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float _powerupFallSpeed = -2f; //Adjustable in inspector for designer

    private Rigidbody2D _rigidbody2D;
    public GameObject _ball;

    private void Awake()
    {
        //Cache
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _rigidbody2D.velocity = new Vector2(0, _powerupFallSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupMultiball(collision);
    }

    private void PowerupMultiball(Collider2D collision)
    {
        var Player = collision.GetComponent<Player>(); //Make sure the collision is the player

        if (Player == null)
            return;

        Instantiate(_ball, transform.position, Quaternion.identity); //Spawn a new ball
        GameSystems.ChangeBallCount(1); //Add to the ball count in GameSystems
    }
}
