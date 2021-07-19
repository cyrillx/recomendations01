using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalMove(1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            HorizontalMove(-1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void HorizontalMove(float direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
    }
}
