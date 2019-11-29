using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMobileControll playerMobileMovement;

    private Vector3 offset;
    private bool gameEnd;

    private void Start()
    {
        offset = transform.position - _camera.transform.position;
    }

    private void Update()
    {
        if (gameEnd)
        {
            CameraViewLoose();
            return;
        }

        _camera.transform.position = transform.position - offset;
        CameraView();
    }

    private void CameraView()
    {
        _camera.fieldOfView = 50 + playerMobileMovement.speed * 6.5f;
    }

    private void CameraViewLoose()
    {
        if (_camera.fieldOfView > 45)
            _camera.fieldOfView -= 45 * Time.deltaTime;
    }

    public void PlayerLoose()
    {
        gameEnd = true;
    }
}
