using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Player
{

    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private int currentState = 0;
    [SerializeField]
    private GameObject playerProjectile;
    public Rigidbody2D playerRigidBody { get => rigidBody; set => rigidBody = value; }
    public Animator PlayerAnimator { get => playerAnimator; set => playerAnimator = value; }
    public int CurrentState { get => currentState; set => currentState = value; }
    public GameObject PlayerProjectile { get => playerProjectile; set => playerProjectile = value; }

}

