using UnityEngine;
using System.Collections;

public class Unit_SC : GridObject_SC
{
    public float moveSpeed = 1f;
    public bool needMirrorPicture = true;
    public GameObject pictureForMirror;

    protected bool isMoving = false;

    #region Unity section
    protected virtual void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, gridPosition, moveSpeed * Time.deltaTime);// Идем в точку стремления с постоянной скоростью
            if (Vector2.Distance(transform.position, gridPosition) <= 0.01f)// Если пришли
            {
                isMoving = false;
            }
        }
    }
    #endregion

    public void TryMove(Vector2Int _deltaPos)
    {
        // Проверки на стороне Юнита
        {
            // Предотвращение некорректных запросов
            if (_deltaPos.x != 0 && _deltaPos.y != 0 ||
                Mathf.Abs(_deltaPos.x) > 1 ||
                Mathf.Abs(_deltaPos.y) > 1)
            {
                Debug.LogError("Некорректная траектория перемещения (" + _deltaPos.x + " ; " + _deltaPos.x + ")");
                return;
            }

            if (isMoving)
            {
                Debug.Log("Другое перемещение еще не завершено");
                return;
            } 
        }

        PictureTurnInMovingSide(_deltaPos);

        // Проверки на стороне карты
        if (!globalMapSc.CheckMoveLegal(gridPosition + _deltaPos))
        {
            Debug.Log("Заявка на перемещение не одобрена");
            return;
        }

        StartMoving(_deltaPos);
    }


    /// <summary>
    /// Начать перемещение
    /// </summary>
    /// <param name="_deltaPos">Сдвиг точки стремления относительно текущей позиции</param>
    void StartMoving(Vector2Int _deltaPos)
    {
        gridPosition += _deltaPos;
        isMoving = true;
    }

    /// <summary>
    /// Отражение картинки в сторону движения
    /// </summary>
    /// <param name="_deltaPos">Сдвиг точки стремления относительно текущей позиции</param>
    void PictureTurnInMovingSide(Vector2Int _deltaPos)
    {
        // Отражение картинки
        if (needMirrorPicture && pictureForMirror)
        {
            Vector3 _currentLocalScale = pictureForMirror.transform.localScale;
            if (_deltaPos.x < 0)
            {
                _currentLocalScale = new Vector3(-Mathf.Abs(_currentLocalScale.x), _currentLocalScale.y, _currentLocalScale.z);
                pictureForMirror.transform.localScale = _currentLocalScale;
            }
            if (_deltaPos.x > 0)
            {
                _currentLocalScale = new Vector3(Mathf.Abs(_currentLocalScale.x), _currentLocalScale.y, _currentLocalScale.z);
                pictureForMirror.transform.localScale = _currentLocalScale;
            }
        }
    }
}
