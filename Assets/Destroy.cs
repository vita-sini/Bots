using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroy : MonoBehaviour
{
    public event UnityAction DestroyResourse;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Resourse resource))
        {
            Destroy(resource.gameObject);
            DestroyResourse?.Invoke();
        }
    }
}
