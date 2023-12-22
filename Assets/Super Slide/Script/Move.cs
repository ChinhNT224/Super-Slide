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

            Vector2 moveDirection = Vector2.zero;

            if (selectedObject.CompareTag("L_R") || selectedObject.CompareTag("Player"))
            {
                moveDirection = new Vector2(mousePosition.x - selectedObject.transform.position.x, 0).normalized;
            }
            else if (selectedObject.CompareTag("U_D"))
            {
                moveDirection = new Vector2(0, mousePosition.y - selectedObject.transform.position.y).normalized;
            }

            selectedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void SelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("Player") || hit.collider != null && hit.collider.CompareTag("L_R") || hit.collider != null && hit.collider.CompareTag("U_D"))
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
            if (selectedObject.CompareTag("Player") && selectedObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Goal")))
            {
                Debug.Log("You Win!");
            }
            else
            {
            }

            selectedObject = null;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player va chạm vào: " + gameObject.name);
            Debug.Log("You Win!");
            PlayerManager.gameWin = true;
        }
    }
}
