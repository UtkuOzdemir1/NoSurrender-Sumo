using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour    
{
    [SerializeField] private float collisionForce = 10f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "Player")
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            rb.AddForce(collisionNormal * collisionForce, ForceMode.Impulse);
        }
        if (collision.collider.tag == "LevelCollider")
        {
            GameManager.Instance.score += 500;
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Collectable")
        {
            Destroy(collision.collider.gameObject);
        }
    }

}
