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
    [SerializeField] private Destroy _destroy;

    private List<Resourse> _resourse = new List<Resourse>();

    private Scan _scan;

    public event UnityAction<int> CountFreeResourse;

    private void Awake()
    {
        _scan = GetComponent<Scan>();
    }

    private void OnEnable()
    {
        _destroy.DestroyResourse += LiberationBot;
    }

    private void OnDisable()
    {
        _destroy.DestroyResourse -= LiberationBot;
    }

    private void Update()
    {
        ReceiveResourse(_scan.GiveResourse());

        IsSetTarget();
    }

    private void LiberationBot(BotMovement botMovement)
    {
        botMovement.SetFree();
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
                if (_botMovement[i].IsFree == true)
                {
                    if(resourse.IsBusy == false)
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
        }

        return false;
    }
}
