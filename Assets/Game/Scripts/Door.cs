using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [field: SerializeField]
    private Animator _animator;

    private bool _isOpen = false;

    public void Interact() => OpenClose();

    private void OpenClose()
    {
        _isOpen = !_isOpen;

        _animator.SetBool("IsOpen", _isOpen);
    }

    public string GetDescription() => _isOpen? "Закрыть" : "Открыть";

    public void OnFocus() {}

    public void OnLoseFocus() {}
}
