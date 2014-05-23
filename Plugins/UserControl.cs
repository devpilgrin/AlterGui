using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Базовый пользовательский контрол
/// </summary>
public class UserControl
{
    protected readonly List<UserControl> childUserControls;

    #region параметры положения и размера компонента

    /// <summary>
    /// Прямоугольник параметры которого возвращают или задают  положение и размера компонента
    /// Дополнительно смотреть здесь: http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
    /// При программировании пользовательских элементов должно быть соблюдено следующее правило:
    /// Получить Rect из Unity Gui Можно только в методе Draw.
    /// </summary>
    protected Rect controlRect;

    /// <summary>
    /// Размер контрола по ширине
    /// </summary>
    public float Width
    {
        get { return controlRect.width; }
        set { controlRect.width = value; }
    }

    /// <summary>
    /// Размер контрола по высоте
    /// </summary>
    public float Height
    {
        get { return controlRect.height; }
        set { controlRect.height = value; }
    }

    /// <summary>
    /// Положение начальной точки координат контрола по оси X
    /// </summary>
    public float X
    {
        get { return controlRect.x; }
        set { controlRect.x = value; }
    }
    
    /// <summary>
    /// Положение начальной точки координат контрола по оси Y
    /// </summary>
    public float Y
    {
        get { return controlRect.y; }
        set { controlRect.y = value; }
    }

    #endregion

    /// <summary>
    /// Получает/Задает расстояние между вертикально границей элемента управления и границей клиентской области контейнера.
    /// </summary>
    public int VerticalBorder { get; set; }

    /// <summary>
    /// Получает/Задает расстояние между горизонтальными границами элемента управления и границей клиентской области контейнера.
    /// </summary>
    public int HorizontalBorder { get; set; }

    
    // Для состояния Visible прописать каждому GUI элементу 
    protected bool visible;
    public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }

    /// <summary>
    /// Дочерние пользовательские элементы управления
    /// </summary>
    public List<UserControl> ChildUserControls
    {
        get { return childUserControls; }
    }

    /// <summary>
    /// Имя контрола
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Родитель данного контрола.
    /// </summary>
    public UserControl ParentUserControl { get; set; }

    /// <summary>
    /// конструктор по умолчанию
    /// </summary>
    protected UserControl()
    {

        Visible = true;
        ParentUserControl = null;
        childUserControls = new List<UserControl>();
        Name = "UserControl";
    }

    /// <summary>
    /// Виртуальный метод для отрисовки всех контролов содержащихся в данном контроле
    /// </summary>
    public virtual void Draw()
    {
        //controlRect = EditorGUILayout.GetControlRect();
        foreach (var childUserControl in childUserControls)
        {
            if(!visible) return;
            childUserControl.Draw();
        }
    }
}


public class CameraControl: UserControl
{
    public readonly Camera camera;

    public CameraControl(Camera _camera)
    {
        camera = _camera;
    }

    public override void Draw()
    {
        if(!camera) return;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Clear Flags");
        camera.clearFlags = (CameraClearFlags)EditorGUILayout.EnumPopup(camera.clearFlags);
        EditorGUILayout.EndHorizontal();

        if (camera.clearFlags == CameraClearFlags.Color)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Background Color");
            camera.backgroundColor = EditorGUILayout.ColorField(camera.backgroundColor);
            EditorGUILayout.EndHorizontal();
        }
        if (camera.clearFlags == CameraClearFlags.Skybox)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Background Color");
            camera.backgroundColor = EditorGUILayout.ColorField(camera.backgroundColor);
            EditorGUILayout.EndHorizontal();
        }
        
    }







}