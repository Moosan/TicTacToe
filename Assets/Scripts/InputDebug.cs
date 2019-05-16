using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDebug : MonoBehaviour
{
    public GameManager GameManager;
    public int x;
    public int y;
    public void Input()
    {
        GameManager.Oku(x, y);
    }
}
