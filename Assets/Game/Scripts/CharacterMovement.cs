using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [field: SerializeField]
    private float _speed;

    private Vector3 _direction;
    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        _direction = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;
        _controller.Move(_direction * _speed * Time.deltaTime);
    }
}
