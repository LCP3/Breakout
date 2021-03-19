using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _ballSpeed = 1f;

    Rigidbody2D _rigidbody2D;
    float _directionX;
    float _directionY;
    private Vector2 _velocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BounceBall(_rigidbody2D, collision.contacts[0].normal);
    }

    private void BounceBall(Rigidbody2D rigidbody2D, Vector2 normal)
    {
        _velocity = Vector2.Reflect(_velocity, normal);
        _rigidbody2D.velocity = _velocity;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _directionX = _ballSpeed;
        _directionY = _ballSpeed;

        _velocity = new Vector2(_directionX, _directionY);
        _rigidbody2D.velocity = _velocity;
    }
}
