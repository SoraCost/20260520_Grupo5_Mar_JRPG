using System;
using UnityEngine;

public class GamemanagerSO : MonoBehaviour
{
    public event Action Onmissionstart;

    public void missionStart()
    {
        Onmissionstart?.Invoke();
    }
}
