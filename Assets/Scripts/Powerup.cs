using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float _powerupFallSpeed = 2f; //Adjustable in inspector for designer

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;

    public GameObject _ball;

    private List<GameObject> powerupsInScene = new List<GameObject>();

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
            PowerupManager.Instance.RemoveFromList(gameObject);
            Destroy(gameObject); //Delete the powerup gameObject
        }
        else if (collision.transform.name == "Death Area")
        {
            //Remove the powerup from the list
            PowerupManager.Instance.RemoveFromList(gameObject);
            Destroy(gameObject); //Delete the powerup gameObject
        }
    }

    private void PowerupMultiball(Collider2D collision)
    {
        var Player = collision.GetComponent<Player>(); //Make sure the collision is the player
        if (Player == null)
            return;

        //Spawn a new ball at position of powerup collision with the player
        BallManager.Instance.SpawnBall(transform.position);
    }
}
