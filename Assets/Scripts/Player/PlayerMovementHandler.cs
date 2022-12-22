using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed = 100f;

    private Touch _touch;

    private Vector3 _touchDown;
    private Vector3 _touchUp;

    private bool _dragStarted;

    void Update()
    {
        if(GameManager.Instance.canMove)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _touchDown = _touch.position;
                _touchUp = _touch.position;
            }
            if(_dragStarted)
            {
                if(_touch.phase == TouchPhase.Moved)
                {
                    _touchDown = _touch.position;
                }
                if(_touch.phase == TouchPhase.Ended)
                {
                    _touchDown = _touch.position;
                    _dragStarted = false;
                }
                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);                
            }
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    Vector3 CalculateDirection()
    {
        Vector3 temp = (_touchDown - _touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
}
