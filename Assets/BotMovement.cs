using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CatchResource _catchResource;
    [SerializeField] private Destroy _destroy;

    public Resourse Resourse;
    private Transform _target;

    private bool _isMove = false;

    public bool IsFree { get; private set; } = true;

    public void SetFree()
    {
        IsFree = true;
    }

    public void ResetFree()
    {
        IsFree = false;
    }

    public void ApplyTaget(Transform target)
    {
        if (target == null)
        {
            return;
        }

        _target = target;
        _isMove = true;

        ResetFree();
    }

    private void OnEnable()
    {
        _catchResource.Ñatch += ApplyTaget;
        _destroy.DestroyResourse += SetFree;
    }

    private void OnDisable()
    {
        _catchResource.Ñatch -= ApplyTaget;
        _destroy.DestroyResourse += SetFree;
    }

    private void Update()
    {
        if (_isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
    }
}
