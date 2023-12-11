using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourse : MonoBehaviour
{
    public bool IsBusy { get; private set; } = false;

    public void SetBusy()
    {
        IsBusy = true;
    }
}
