using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private float _cameraSpeed = 1f;

    private Transform _transform;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        // On calcule la nouvelle position de la cam grace Vector2.Lerp
        Vector3 newPos = Vector2.Lerp(_transform.position, _playerTransform.position, _cameraSpeed * Time.deltaTime);
        // On remet le Z initial de la cam (par défaut à -10)
        newPos.z = _transform.position.z;
        // On applique la nouvelle position
        _transform.position = newPos;
    }
}
