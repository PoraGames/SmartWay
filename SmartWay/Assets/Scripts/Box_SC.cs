using UnityEngine;
using System.Collections;

public class Box_SC : Unit_SC
{
    public bool isStayOnPoint = false;
    public Sprite offPicture;
    public Sprite onPicture;

    private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        // Глубокий поиск, если нужно
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!spriteRenderer)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnPointEnter()
    {
        isStayOnPoint = true;
        spriteRenderer.sprite = onPicture;
    }

    public void OnPointExit()
    {
        isStayOnPoint = false;
        spriteRenderer.sprite = offPicture;
    }
}
