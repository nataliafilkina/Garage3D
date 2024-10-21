using UnityEngine;

public class Hand : MonoBehaviour
{
    [field: SerializeField]
    private float _throwForce;
    private Transform _itemInHand;
    private Rigidbody _itemRigitBody;
    
    private void Update()
    {
        if(_itemInHand != null && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    public void Drag(Transform item)
    {
        if (_itemInHand == null)
        {
            _itemInHand = item;
            _itemInHand.TryGetComponent(out _itemRigitBody);
            if (_itemRigitBody != null)
            {
                _itemRigitBody.isKinematic = true;
                _itemInHand.transform.parent = transform;
                _itemInHand.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void Drop()
    {
        _itemInHand.transform.parent = null;
        _itemRigitBody.isKinematic = false;
        _itemRigitBody.AddForce(Camera.main.transform.forward * _throwForce);

        _itemInHand = null;
        _itemRigitBody = null;
    }
}
