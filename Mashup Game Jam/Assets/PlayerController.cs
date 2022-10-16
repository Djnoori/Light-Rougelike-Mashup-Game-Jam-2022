using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private bool active = true;

    private Rigidbody2D rb;

    [SerializeField] private GameObject shopUI;

    private GameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Only run these things if the player is active
        if (active == true)
        {
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If colliding with a portal, go to the room assigned to the portal
        if (other.tag == "Portal")
        {
            manager.ToRoom(other.GetComponent<Portal>().portalNum.ToString());
        }

        // If colliding with the shop, open the shop UI
        if (other.tag == "Shop")
        {
            shopUI.SetAcitve(true);
        }
    }

    // Handles movement
    void Move()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        // Isn't it crazy that vMove has two Vs in it? Vs are pretty rare tbh
        rb.velocity = new Vector2(hMove * speed, vMove * speed);
    }
}
