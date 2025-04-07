using UnityEngine;

public class moveResearchUI : MonoBehaviour
{
    private const int negateMove = -1;
    public int moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        
        if (direction != Vector2.zero)
        {
            direction = direction.normalized;
            MoveUI(direction);
        }
    }

    void MoveUI(Vector2 direction)
    {
        transform.Translate(direction * (moveSpeed * Time.deltaTime * negateMove));
    }
}
