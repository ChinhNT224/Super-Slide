using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isMoving = false;
    private GameObject selectedObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
        MovePlayer();
    }

    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DeselectObject();
        }
    }

    void MovePlayer()
    {
        if (isMoving && selectedObject != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            Vector2 moveDirection = (mousePosition - selectedObject.transform.position).normalized;

            selectedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void SelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            isMoving = true;
            selectedObject = hit.collider.gameObject;
        }
    }

    void DeselectObject()
    {
        isMoving = false;
        if (selectedObject != null)
        {
            Vector2 currentPosition = selectedObject.transform.position;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            float distance = Vector2.Distance(selectedObject.transform.position, mousePosition);
            int moves = 0;

            if (distance > 0.6f)
            {
                int roundedX = Mathf.RoundToInt(currentPosition.x / 0.6f);
                float remainder = currentPosition.x % 0.6f;

                float newX = 0f;

                if (remainder < 0.3f)
                {
                    newX = roundedX * 0.6f;
                }
                else
                {
                    newX = (roundedX + Mathf.Sign(mousePosition.x - currentPosition.x)) * 0.6f;
                }

                float newY = Mathf.Round(currentPosition.y / 0.6f) * 0.6f;

                selectedObject.transform.position = new Vector2(newX, newY);

                moves++;
                Debug.Log("Moves: " + moves);
                selectedObject = null;
            }
        }
    }

}
