using UnityEngine;
using TMPro;

public class CharacterInteraction : MonoBehaviour
{
    [field: SerializeField]
    private float _interactionDistance;

    [field: SerializeField]
    private GameObject _interactionUI;

    [field: SerializeField]
    private TextMeshProUGUI _intercationText;
    private string _keyText = " [E]";

    private Camera _camera;
    private IInteractable _lastObject;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update() => InteractionRay();

    private void InteractionRay()
    {
        bool isHit = false;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _interactionDistance))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable)) 
            {
                if(_lastObject != null)
                    _lastObject.OnLoseFocus();

                _lastObject = interactable;
                isHit = true;
                _intercationText.text = interactable.GetDescription() + _keyText;
                interactable.OnFocus();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(); 
                }
            }
            else
                if(_lastObject != null)
                {
                    _lastObject.OnLoseFocus();
                    _lastObject = null;
                }
        }

        _interactionUI.SetActive(isHit);
    }
}
