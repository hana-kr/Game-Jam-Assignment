using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
 
    public UnityEvent UpdatedBirds;
    public UnityEvent UpdatedCoins;
    public UnityEvent GameOver;
    public UnityEvent Win;

    void Awake()
    {
        UpdatedCoins = new UnityEvent();
        UpdatedBirds = new UnityEvent();
        GameOver = new UnityEvent();
        Win = new UnityEvent();
    }
}
