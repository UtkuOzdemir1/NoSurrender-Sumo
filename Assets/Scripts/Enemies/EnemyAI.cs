using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    private GameObject target;
    void Update()
    {
        if(target == null)
        {
            FindClosestTarget();
        }
        else
        {
            if (GameManager.Instance.canMove)
            {
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
            }
        }
    }

    void FindClosestTarget()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Collectable");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject item in gameObjects)
        {
            Vector3 diff = item.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if(currentDistance < distance)
            {
                closest = item;
                distance = currentDistance;
            }
        }
        target = closest;
    }
}


