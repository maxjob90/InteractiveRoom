using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    private bool _isOpen;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SwitchDoorState()
    {
        _isOpen = !_isOpen;
        _animator.SetBool(IsOpen, _isOpen);
    }
}