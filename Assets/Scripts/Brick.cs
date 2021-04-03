using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] float _powerupChance = 1f;

    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;
    private ParticleSystem _particleSystem;
    public Rigidbody2D _powerup;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collider2D.enabled = false;
        _spriteRenderer.enabled = false;
        _particleSystem.Play();
        GameSystems.AddScore(100);

        //Roll random number
        float _randomNumber = Random.Range(0, 10f);
        //If it's within the determined range
        if (_randomNumber <= _powerupChance)
        {
            //Spawn a powerup
            Instantiate(_powerup, transform.position, Quaternion.identity);
        }
    }
}
