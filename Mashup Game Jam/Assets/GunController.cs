using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Vector2 offset;

    [SerializeField] private GameObject player;

    private Camera cam;
    private PlayerController playerCon;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        playerCon = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        LockPosition();
    }

    // Locks the position of the gun to the player using the offset variable and handles rotation
    void LockPosition()
    {
        if (playerCon.flipped == false)
        {
            transform.position = player.transform.position + new Vector3(offset.x, offset.y, 0);
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else
        {
            transform.position = player.transform.position + new Vector3(-offset.x, offset.y, 0);
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
