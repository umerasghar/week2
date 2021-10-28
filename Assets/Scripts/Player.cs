using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Player
{

    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private int currentState = 0;
    public Rigidbody2D Rb2D { get => rb2D; set => rb2D = value; }
    public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
    public int CurrentState { get => currentState; set => currentState = value; }
}

