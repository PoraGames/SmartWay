using UnityEngine;
using System.Collections;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

public interface ITask
{
    bool IsCompleted();
}

[ExecuteInEditMode]
public class TaskController_SC : MonoBehaviour
{
    /// <summary>
    /// Все задания уровня
    /// </summary>
    [Header("Все задачи уровня")] public GameObject[] tasks;

    void Update()
    {
#if UNITY_EDITOR
        // Автоматически удаляем все объекты, которые не реализуют интерфейс ITask
        for (int i = 0; i < tasks.Length; ++i)
        {
            if (!(tasks[i].GetComponent<MonoBehaviour>() is ITask))
            {
                Debug.LogError(tasks[i].name + " Не содержит задания");
                tasks = tasks.Where((val, idx) => idx != i).ToArray(); // Убрать из массива элемент
            }
        }
#endif

        CheckTasksComplete();// TODO: Перестать вызывать в Uodate()
    }

    /// <summary>
    /// Проверить на выполненность все задания
    /// </summary>
    /// <returns>true если все задания выполнены</returns>
    bool CheckTasksComplete()
    {
        for (int i = 0; i < tasks.Length; ++i)
        {
            if (!((ITask) tasks[i].GetComponent<MonoBehaviour>()).IsCompleted())
            {
                return false;
            }
        }

        Debug.Log("Уровень завершен =)");
        return true;
    }
}
