using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] float _horizontal;

    public float GetHoriztonalInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved 
                && Mathf.Abs(touch.deltaPosition.x) < 80)
            {

                _horizontal = touch.deltaPosition.x;
                return _horizontal;
            }
            else
            {
                _horizontal = 0;
                return _horizontal;
            }
            
        }
        return _horizontal;
    }
}


