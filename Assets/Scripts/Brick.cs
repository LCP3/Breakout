using UnityEngine;

public class Brick : MonoBehaviour
{
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _collider2D.enabled = false;
        _spriteRenderer.enabled = false;
        GameSystems.AddScore(100);        
    }
}
