using UnityEngine;
using TicGame;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public GameObject MaruPrefab;
    public GameObject BatuPrefab;
    private GameLogic GameLogic;
    private Mark NextTurn;
    private List<>
    
    void Start()
    {
        NextTurn = Mark.Maru;
        GameLogic = new GameLogic(NextTurn);
    }

    public void Oku(int x,int y)
    {
        var result = GameLogic.Action(x, y,NextTurn);
        if (!result.IsSuccess)
        {
            Debug.Log("置けませんでした");
            return;
        }

        InstanceObj(x, y);

        if (result.Winner != Mark.None)
        {
            Debug.Log((result.Winner == Mark.Maru ? "まる" : "ばつ") + "の勝ち!!");
            return;
        }
        if (result.IsFull)
        {
            Debug.Log("引き分け!!");
            return;
        }
        NextTurn = result.NextTurn;
    }
    private void InstanceObj(int x,int y)
    {
        if (NextTurn == Mark.None) return;
        var obj = NextTurn == Mark.Maru ? MaruPrefab : BatuPrefab;
        Instantiate(obj, new Vector3(x, y, 0), new Quaternion());
    }
}
