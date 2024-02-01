using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private float _ejectionForce;
    private GameObject _gameObject;

    private void Start()
    {
        _gameObject = GameObject.Find("InteractableInventory");
    }

    private void Update()
    {
        if (transform.childCount <= 0 || !Input.GetMouseButtonDown(0)) return;
        var childObject = transform.GetChild(0).gameObject;
        var force = Camera.main.transform.forward * _ejectionForce;
        childObject.transform.SetParent(_gameObject.transform);
        childObject.GetComponent<Rigidbody>().isKinematic = false;
        childObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}