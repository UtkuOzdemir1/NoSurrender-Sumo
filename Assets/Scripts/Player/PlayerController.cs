using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Collectable")
        {
            GameManager.Instance.score += 100;
        }

        if (collision.collider.tag == "LevelCollider")
        {
            GameManager.Instance.State = GameState.Lose;
            Debug.Log("Am I dead");
        }
    }
}
