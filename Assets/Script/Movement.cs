using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _horizontal;
    [SerializeField] float _horizontalSpeed;
    [SerializeField] float _verticalSpeed;
    

    private float _newPos;
    private float _newPos1;
    private InputManager input;
    private void Awake()
    {
        input = new InputManager();
    }

    private void Update()
    {
        _horizontal=input.GetHoriztonalInput();


    }
    private void FixedUpdate()
    {

        moveForward();
        moveHorizontal();

        if (GameManager.Instance.IsGameOver)
        {

        }

    }
    private void moveForward()
    {
        transform.Translate(Vector3.forward * _verticalSpeed * Time.fixedDeltaTime);
        if (MergeController.Instance.PlayerCubes.Count>0)
        {
            for (int i = 0; i < MergeController.Instance.PlayerCubes.Count; i++)
            {
                MergeController.Instance.PlayerCubes[i].transform.
                    Translate(Vector3.forward * _verticalSpeed * Time.fixedDeltaTime);
            }

        }

    }

    private void moveHorizontal()
    {
        _newPos = transform.position.x + _horizontal * Time.fixedDeltaTime * _horizontalSpeed;


        if (_newPos < 4.5f && _newPos > -4.5f)
        {
            transform.position = new Vector3(_newPos, transform.position.y, transform.position.z);
            if (MergeController.Instance.PlayerCubes.Count > 0)
            {
                for (int i = 0; i < MergeController.Instance.PlayerCubes.Count; i++)
                {
                    _newPos1 = MergeController.Instance.PlayerCubes[i].transform.position.x + _horizontal * Time.fixedDeltaTime * _horizontalSpeed;
                    MergeController.Instance.PlayerCubes[i].transform.position = new Vector3
                        (_newPos1, MergeController.Instance.PlayerCubes[i].transform.position.y, MergeController.Instance.PlayerCubes[i].transform.position.z);
                }

            }
        }



    }
}
