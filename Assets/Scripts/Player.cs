using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int Number = 0;

    public int Index;

    private void Awake()
    {
        Index = Number;
        Number++;
    }
}
