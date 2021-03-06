﻿using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Объект плотно взаимодействующий с "сеткой челых значений".
/// Выравнивается по ней, обменивается данными
/// </summary>
public class GridObject_SC : MonoBehaviour
{
    /// <summary>
    /// Позиция клетки в реальном мире (она же позиция в глобальном массиве)
    /// </summary>
    public Vector2Int gridPosition;

    // Ссылка на глобальную карту
    protected GlobalMap_SC globalMapSc;

    #region Unity section
    protected virtual void Start()
    {
        if (globalMapSc == null)
            globalMapSc = FindObjectOfType<GlobalMap_SC>();

        StartMovesAndEffects();
        RegisterInGlobalClasses();

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    protected virtual void OnDrawGizmos()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    #endregion

    /// <summary>
    /// Выравнивание позиции до целых координат
    /// <para>и запуск всех стартовых процессов</para>
    /// </summary>
    protected virtual void StartMovesAndEffects()
    {
        Vector2Int _roundedIntPos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        gridPosition = _roundedIntPos;
        transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
    }

    protected virtual void RegisterInGlobalClasses() { }
}
