using UnityEngine;

public class Selection : MonoBehaviour
{
    public Color AddColorWithEnter;
    public Tree Tree;

    private SpriteRenderer sprite;
    private Color currentAddedColor;
    private Color clearColor = new Color(1, 1, 1, 1);
    private bool isClear;

    public void OnClick()
    {
        Tree.ReduceHealth();
    }

    public void OnEnter()
    {
        currentAddedColor = AddColorWithEnter;
        isClear = false;
    }

    public void OnExit()
    {
        isClear = true;
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentAddedColor = clearColor;
    }

    private void FixedUpdate()
    {
        if (isClear)
        {
            currentAddedColor = Color.Lerp(currentAddedColor, clearColor, Time.deltaTime);
        }
        sprite.color = currentAddedColor;
    }
}