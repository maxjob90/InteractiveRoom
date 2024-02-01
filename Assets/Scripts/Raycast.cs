using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Update()
    {
      var ray = new Ray(transform.position, transform.forward);
      Debug.DrawRay(transform.position, transform.forward, Color.black);
      if (!Physics.Raycast(ray, out var hitInfo)) return;
      var hitObject = hitInfo.collider.gameObject;
      if (hitObject.GetComponent<Door>() && Input.GetKeyDown(KeyCode.E))
      {
          hitObject.GetComponent<Door>().SwitchDoorState();
      }
    }
}