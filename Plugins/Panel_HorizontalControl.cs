using UnityEditor;
using UnityEngine;

/// <summary>
/// Горизонтальная панель
/// </summary>
public class Panel_HorizontalControl : PanelControl
{
    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    public Panel_HorizontalControl()
    {
        borderStyle = convertBorder(PanelBorder.WindowBackground);
    }

    /// <summary>
    /// Конструктор контрола
    /// </summary>
    /// <param name="_border">Визуальный стиль контрола</param>
    public Panel_HorizontalControl(PanelBorder _border)
    {
        borderStyle = convertBorder(_border);
    }

    /// <summary>
    /// Метод отображения контрола и всех его детей
    /// </summary>
    public override void Draw()
    {
        if (!visible) return;
        GUILayout.Space(2);
        EditorGUILayout.BeginHorizontal(borderStyle);
        foreach (var childUserControl in childUserControls)
        {   
            GUILayout.Space(2);
            EditorGUILayout.BeginVertical();
            childUserControl.Draw();
            GUILayout.Space(2);
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
    }
}