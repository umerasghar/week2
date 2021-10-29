using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventTriggers : MonoBehaviour
{
    public static EventTriggers instance;
    private void Awake()
    {
        instance = this;
    }
    public delegate void UpdateUI();
    public static UpdateUI onEnemyDead;

}
