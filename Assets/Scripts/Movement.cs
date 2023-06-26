using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;

    private float _rightDirection = 1f;
    private float _leftDirection = -1f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            MoveHorizontal(_rightDirection);

        if (Input.GetKey(KeyCode.A))
            MoveHorizontal(_leftDirection);

        if (Input.GetKeyDown(KeyCode.D))
            _spriteRenderer.flipX = false;

        if (Input.GetKeyDown(KeyCode.A))
            _spriteRenderer.flipX = true;
    }

    private void MoveHorizontal(float direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
    }
}
