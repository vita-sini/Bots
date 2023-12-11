using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Scan))]
public class Base : MonoBehaviour
{
    [SerializeField] private BotMovement[] _botMovement;

    private List<Resourse> _resourse = new List<Resourse>();

    private Scan _scan;

    public event UnityAction<int> CountFreeResourse;

    private void Awake()
    {
        _scan = GetComponent<Scan>();
    }

    private void Update()
    {
        ReceiveResourse(_scan.GiveResourse());

        IsSetTarget();
    }

    private void ReceiveResourse(List<Resourse> resourses)
    {
        if (resourses != null)
        {
            foreach (Resourse resourse in resourses)
            {
                if (!_resourse.Contains(resourse))
                {
                    _resourse.Add(resourse);
                    Debug.Log(_resourse.Count);
                    CountFreeResourse?.Invoke(_resourse.Count);
                }
            }
        }
    }

    private bool IsSetTarget()
    {
        foreach (var resourse in _resourse)
        {
            for (int i = 0; i < _botMovement.Length; i++)
            {
                if (resourse.IsBusy == false && _botMovement[i].IsFree == true)
                {
                    if (resourse != null)
                    {
                        resourse.SetBusy();
                        _botMovement[i].ApplyTaget(resourse.transform);
                        _botMovement[i].Resourse = resourse;
                    }

                    _resourse.Remove(resourse);

                    CountFreeResourse?.Invoke(_resourse.Count);

                    return true;
                }
            }
        }

        return false;
    }
}
