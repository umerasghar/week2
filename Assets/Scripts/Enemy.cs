using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Enemy 
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float health;
    [SerializeField]
    private Animator animator;
    private bool isDead;
    public Rigidbody2D enemyRigidBody { get => rigidBody; set => rigidBody = value; }
    public float Health { get => health; set => health = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public Animator Animator { get => animator; set => animator = value; }
}
