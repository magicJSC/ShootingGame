using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance; 
    static GameManager _instance;

    void Awake()
    {
        _instance = this;
    }

    public Transform player;
    public float score;
}
