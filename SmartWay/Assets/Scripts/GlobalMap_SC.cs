using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalMap_SC : MonoBehaviour
{
    public Dictionary<Vector2Int, MapQuad_SC> landObjects = 
        new Dictionary<Vector2Int, MapQuad_SC>();

    [Space(30)]
    [Header("Информация о карте уровня"), Space(15)]

    [Header("Количество объектов земли")]
    public int landsObjects = 0;

    /// <summary>
    /// Внести всю нежную информацию о клетке в массивы,
    /// и саму клетку внести в массив клеток
    /// </summary>
    /// <param name="_mapQuadSc">регистрируемая клетка</param>
    public void RegisterLandInGlobalMap(MapQuad_SC _mapQuadSc)
    {
        Vector2Int _key = _mapQuadSc.gridPosition;

        if (!landObjects.ContainsKey(_key))
        {
            landObjects.Add(_key, _mapQuadSc);

            ++landsObjects;
        }
        else
        {
            Debug.LogError("Ключ " + _key + " уже используется");
        }
    }

    public bool CheckMoveLegal(Vector2Int _posForCheck)
    {
        if (landObjects.ContainsKey(_posForCheck))
        {
            return landObjects[_posForCheck].isOpen;
        }

        Debug.Log("Передвижение вне карты");
        return true;
    }
}
