using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    [SerializeField] int value = 100;

    public int GetValue() { return value; }
}
