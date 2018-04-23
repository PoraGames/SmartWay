using UnityEngine;
using System.Collections;

public class ProgressBar_SC : MonoBehaviour
{
    public Transform pictureRoot;

    /// <summary> Заполненная часть </summary>
    [Range(0, 1)]
    public float fullPart = 0;

    protected virtual void Start()
    {
        UpdatePictureSize();
    }

    /// <summary>
    /// Задать новое значение заполненности
    /// </summary>
    /// <param name="_fullPart">заполненная часть</param>
    public virtual void SetFullPart(float _fullPart)
    {
        if (_fullPart < 0 || _fullPart > 1)// Проверка корректности значения
        {
            Debug.LogError("Progress bar value out of range [0; 1]");
            return;
        }

        fullPart = _fullPart;
        UpdatePictureSize();
    }

    /// <summary>
    /// Изменить заполненность <see cref="ProgressBar_SC"/>
    ///  на основании <see cref="fullPart"/>
    /// </summary>
    protected virtual void UpdatePictureSize()
    {
        pictureRoot.localScale = new Vector3(fullPart, 1, 1);
    }
}
