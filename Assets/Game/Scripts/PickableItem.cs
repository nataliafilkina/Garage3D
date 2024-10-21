using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableItem : MonoBehaviour, IInteractable
{
    [field: SerializeField]
    private Hand _hand;

    private Outline _outline;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    public string GetDescription() => "Взять";

    public void Interact() => _hand.Drag(transform);

    public void OnFocus() => _outline.enabled = true;

    public void OnLoseFocus() => _outline.enabled = false;
}
