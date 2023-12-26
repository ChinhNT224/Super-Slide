using UnityEngine;
using System.Collections.Generic;

public class MoveController : MonoBehaviour
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
            mousePosition.z = selectedObject.transform.position.z;

            Vector2 moveDirection = Vector2.zero;

            if (selectedObject.CompareTag("Player") && (Mathf.Abs(mousePosition.x - selectedObject.transform.position.x) > Mathf.Abs(mousePosition.y - selectedObject.transform.position.y)))
            {
                moveDirection = new Vector2(mousePosition.x - selectedObject.transform.position.x, 0).normalized;
            }
            else if (selectedObject.CompareTag("Player") && (Mathf.Abs(mousePosition.x - selectedObject.transform.position.x) < Mathf.Abs(mousePosition.y - selectedObject.transform.position.y)))
            {
                moveDirection = new Vector2(0, mousePosition.y - selectedObject.transform.position.y).normalized;
            }

            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
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
            selectedObject = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.Sleep();
    }
}
