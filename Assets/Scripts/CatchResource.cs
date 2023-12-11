using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BotMovement))]
public class CatchResource : MonoBehaviour
{
    [SerializeField] private Base _base;

    public event UnityAction<Transform> Ñatch;

    private BotMovement _botMovement;

    private void Awake()
    {
        _botMovement = GetComponent<BotMovement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Resourse resource) && _botMovement.Resourse == resource)
        {
            resource.transform.SetParent(transform);
            resource.transform.position = transform.position;
            Ñatch?.Invoke(_base.transform);
        }
    }
}
