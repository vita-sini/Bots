using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroy : MonoBehaviour
{
    public event UnityAction<BotMovement> DestroyResourse;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out BotMovement botMovement))
        {
            DestroyResourse?.Invoke(botMovement);
        }
    }
}
