using UnityEditor;
using UnityEngine;

public class HorizontalHeaderControl : PanelControl
{
    public string Label { get; set; }


    public HorizontalHeaderControl(string _label)
    {
        Label = _label;
    }

    /// <summary>
    /// ����� ����������� �������� � ���� ��� �����
    /// </summary>
    public override void Draw()
    {
        if (!visible) return;
        //EditorGUILayout.BeginVertical("SelectionRect");
        GUILayout.Label(Label, "OL Title");
        GUILayout.Space(1);
        //EditorGUILayout.EndVertical();
    }
}