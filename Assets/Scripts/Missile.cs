using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] protected int _Health = 1;
    [SerializeField] protected int _Damage = 1;
    [SerializeField] protected float _Speed = 1;
    
    public int Health { get => _Health; set => _Health = value; }

}
