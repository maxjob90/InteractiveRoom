using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private int _highlightIntensity = 4;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _maxDistance = 5f;
    private Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void Update()
    {
        var cameraTransform = Camera.main.transform;
        var outline = _transform.gameObject.GetComponentInChildren<Outline>();
        var ray = new Ray(cameraTransform.position, cameraTransform.transform.forward);
       
        if (GetComponent<Collider>().Raycast(ray, out var hitInfo, _maxDistance))
        {
            if (!hitInfo.collider.CompareTag("Player"))
            {
                Debug.DrawRay(cameraTransform.position, cameraTransform.forward*hitInfo.distance, Color.black);

            }
            
            var hitObject = hitInfo.collider.gameObject;
            SetFocus();
            
            if (!Input.GetKeyDown(KeyCode.E)) return;
            TakeTheItem(hitObject);
            
            if (outline == null) return;
            AskNewParent();
            
        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward*_maxDistance, Color.black);
            RemoveFocus();
        }
    }

    private void TakeTheItem(GameObject hitObject)
    {
        RemoveFocus();
        hitObject.GetComponent<Rigidbody>().isKinematic = true;
        hitObject.transform.position = _transform.position;
        hitObject.transform.SetParent(_transform);
    }

    private void AskNewParent()
    {
        var childObject = _transform.GetChild(0).gameObject;
        var newParent = GameObject.Find("InteractableInventory");
        childObject.transform.SetParent(newParent.transform);
        childObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void SetFocus()
    {
        _outline.OutlineWidth = _highlightIntensity;
    }

    private void RemoveFocus()
    {
        _outline.OutlineWidth = 0;
    }
}