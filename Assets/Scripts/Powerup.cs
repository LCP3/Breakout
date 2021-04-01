using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float _powerupFallSpeed = -2f; //Adjustable in inspector for designer

    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D _ball;

    private void Awake()
    {
        //Cache
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
        _rigidbody2D.velocity = new Vector2(0, _powerupFallSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Player = collision.GetComponent<Player>();

        if (Player == null)
            return;

        Instantiate(_ball, new Vector2(1f, 1f), Quaternion.identity);
    }
}
