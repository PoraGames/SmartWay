using UnityEngine;
using System.Collections;

/// <summary>
/// Точка ожидания
/// </summary>
public class WaiterPointForBox_SC : MonoBehaviour
{

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Box_SC _boxSc = collision.transform.GetComponent<Box_SC>();
        if (_boxSc)
        {
            _boxSc.OnPointEnter();
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        Box_SC _boxSc = collision.transform.GetComponent<Box_SC>();
        if (_boxSc)
        {
            _boxSc.OnPointExit();
        }
    }
}
