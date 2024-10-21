using UnityEngine;

public class CameraController : MonoBehaviour
{
    [field: SerializeField]
    private float _sensitivity;

    [field: SerializeField]
    private float _smooth;

    private Transform _character;

    private float _xRotation;
    private float _yRotation;

    private void Start()
    {
        _character = transform.parent;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _xRotation -= Input.GetAxis("Mouse Y") * _sensitivity;
        _yRotation += Input.GetAxis("Mouse X") * _sensitivity;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_xRotation, _yRotation, 0), Time.deltaTime * _smooth);
        _character.rotation = Quaternion.Lerp(_character.rotation, Quaternion.Euler(0, _yRotation, 0), Time.deltaTime * _smooth);
    }
}
