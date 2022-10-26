using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager GameManager_Script;
    public float Sensivility;

    private void Awake()
    {
        GameManager_Script = this;
    }
}
