using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AvailableResources : MonoBehaviour
{
    [SerializeField] private TMP_Text _freeCountResourse;
    [SerializeField] private Base _base;

    private void OnDisable()
    {
        _base.CountFreeResourse += ChangedText;
    }

    private void OnEnable()
    {
        _base.CountFreeResourse -= ChangedText;
    }

    private void ChangedText(int freeCountResourse)
    {
        _freeCountResourse.text = freeCountResourse.ToString();
    }
}
