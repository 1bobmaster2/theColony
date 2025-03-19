using UnityEngine;

public class moveResearchUI : MonoBehaviour
{
    public int negateMove = -1;
    public int moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUI(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveUI(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveUI(Vector2.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveUI(Vector2.right);
        }
    }

    void MoveUI(Vector2 direction)
    {
        transform.Translate(direction * (moveSpeed * Time.deltaTime * negateMove));
    }
}
