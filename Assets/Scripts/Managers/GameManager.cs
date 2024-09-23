using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _playerDetectionRadius;
    [SerializeField] private float _townDetectionRadius;

    public float PlayerDetectionRadius { get => _playerDetectionRadius; }
    public float TownDetectionRadius { get => _townDetectionRadius; }
}
