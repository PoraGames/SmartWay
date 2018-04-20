using UnityEngine;
using System.Collections;

public class UnitUnderPlayerControl_SC : Unit_SC
{
    protected override void Update()
    {
        base.Update();

        InputReader();
    }

    void InputReader()
    {
        if (Input.GetKeyDown(KeyCode.A))
            TryMove(new Vector2Int(-1, 0));
        if (Input.GetKeyDown(KeyCode.D))
            TryMove(new Vector2Int(1, 0));
        if (Input.GetKeyDown(KeyCode.W))
            TryMove(new Vector2Int(0, 1));
        if (Input.GetKeyDown(KeyCode.S))
            TryMove(new Vector2Int(0, -1));

    }
}
