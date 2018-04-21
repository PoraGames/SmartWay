using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalMap_SC : MonoBehaviour
{
    public Dictionary<Vector2Int, MapQuad_SC> landObjects = 
        new Dictionary<Vector2Int, MapQuad_SC>();
    public Dictionary<Vector2Int, Unit_SC> landUnits =
        new Dictionary<Vector2Int, Unit_SC>();

    [Space(30)]
    [Header("Информация о карте уровня"), Space(15)]

    [Header("Количество объектов земли")]
    public int landsObjectsQuantity = 0;
    [Header("Количество юнитов")]
    public int landsUnitsQuantity = 0;

    #region Registration
    /// <summary>
    /// Внести всю нежную информацию о клетке в массивы,
    /// и саму клетку внести в массив клеток
    /// </summary>
    /// <param name="_objectForRegister">регистрируемая клетка</param>
    public void RegisterInGlobalMap(MapQuad_SC _objectForRegister)
    {
        Vector2Int _key = _objectForRegister.gridPosition;

        if (!landObjects.ContainsKey(_key))
        {
            landObjects.Add(_key, _objectForRegister);

            ++landsObjectsQuantity;
        }
        else
        {
            Debug.LogError("Ключ " + _key + " уже используется");
        }
    }

    /// <summary>
    /// Внести всю нежную информацию о юните в массивы,
    /// и самого юнита внести в массив юнитов
    /// </summary>
    /// <param name="_objectForRegister">регистрируемый юнит</param>
    public void RegisterInGlobalMap(Unit_SC _objectForRegister)
    {
        Vector2Int _key = _objectForRegister.gridPosition;

        if (!landUnits.ContainsKey(_key))
        {
            landUnits.Add(_key, _objectForRegister);

            ++landsUnitsQuantity;
        }
        else
        {
            Debug.LogError("Ключ " + _key + " уже используется");
        }
    }
    #endregion

    /// <summary>
    /// Проверить возможность передвижения
    /// </summary>
    /// <param name="_posForCheck">Куда идет?</param>
    /// <param name="_moveUnit">Кто идет?</param>
    /// <returns></returns>
    public bool CheckMoveLegal(Vector2Int _posForCheck, Unit_SC _moveUnit)
    {
        if (landObjects.ContainsKey(_moveUnit.gridPosition + _posForCheck))
        {
            if (!landObjects[_moveUnit.gridPosition + _posForCheck].isOpen)
                return false;
        }

        if (landUnits.ContainsKey(_moveUnit.gridPosition + _posForCheck))
        {
            if (!landUnits[_moveUnit.gridPosition + _posForCheck].TryMove(_posForCheck))
                return false;
        }

        MoveElementInDictionary(_posForCheck, _moveUnit);
        return true;
    }

    void MoveElementInDictionary(Vector2Int _posForCheck, Unit_SC _moveUnit)
    {
        landUnits.Add(_moveUnit.gridPosition + _posForCheck, _moveUnit);
        landUnits.Remove(_moveUnit.gridPosition);
    }
}
