using UnityEditor;
using UnityEngine;

/// <summary>
/// Вертикальная панель
/// </summary>
public class PanelControl : UserControl
{
    internal string borderStyle;
    
    public PanelBorder BorderStyle
    {
        set { borderStyle = convertBorder(value); }
    }

    /// <summary>
    /// Добавляет UserControl к данному контролу
    /// </summary>
    /// <param name="control"></param>
    public void AddControl(UserControl control)
    {
        childUserControls.Add(control);
    }

    /// <summary>
    /// Добавляет UserControl-ы указанной коллекции к данному контролу
    /// </summary>
    /// <param name="controls">Коллекция UserControl</param>
    public void AddRangeControls(UserControl[] controls)
    {
        foreach (var control in controls)
        {
            control.ParentUserControl = this;
        }
        childUserControls.AddRange(controls);
    }

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public PanelControl()
    {
        borderStyle = convertBorder(PanelBorder.WindowBackground);
    }
    
    /// <summary>
    /// Конструктор контрола
    /// </summary>
    /// <param name="_border">Визуальный стиль контрола</param>
    public PanelControl(PanelBorder _border)
    {
        borderStyle = convertBorder(_border);
    }

    public override void Draw()
    {
        if(!visible) return;
        EditorGUILayout.BeginVertical("HelpBox");
        GUILayout.Space(2);


        foreach (var childUserControl in childUserControls)
        {
            childUserControl.Draw();
        }

        GUILayout.Space(2);
        EditorGUILayout.EndVertical();
    }

    //Конвертация PanelBorder в строковое представление GUIStyle
    internal string convertBorder(PanelBorder _border)
    {
        if (_border == PanelBorder.None) return "";
        return _border.ToString();
    }
}