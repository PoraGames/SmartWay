using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Неподвижный элемент карты,
/// имеющий целые показатели длины и ширины
/// </summary>
public class MapQuad_SC : GridObject_SC
{
    [Header("Проходимая")]
    public bool isOpen = false;

    /// <summary>
    /// Регистрация в глобальных массивах
    /// </summary>
    protected override void RegisterInGlobalClasses()
    {
        globalMapSc.RegisterInGlobalMap(this);
    }
}
