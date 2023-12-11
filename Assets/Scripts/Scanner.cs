using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private List<Resourse> _resourse = new List<Resourse>();

    private float radius = 360f;
    private float maxDistance = Mathf.Infinity;

    private void Update()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, radius, 
            Vector3.one, maxDistance, _layerMask);

        foreach (RaycastHit hit in raycastHits)
        {
            if (hit.collider.TryGetComponent(out Resourse resource))
            {
                if (!_resourse.Contains(resource) && resource.IsBusy == false)
                {
                    _resourse.Add(resource);
                }
            }
        }
    }

    public List<Resourse> GiveResourse()
    {
        List<Resourse> resourses = new List<Resourse>();

        for (int i = 0; i < _resourse.Count; i++)
        {
            resourses.Add(_resourse[0]);
            _resourse.Remove(_resourse[0]);
        }

        return resourses;
    }
}
