using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameObject))]
public class GameObjectEditor: Editor
{

    public static ObjectControl OC;
    
    public Rect windowRect = new Rect(0, 17, 120, 50);

    public override void OnInspectorGUI()
    {
 
        EditorGUILayout.HelpBox("Данный инспектор переопределен.\nНекоторые возможности стандартного инспектора не доступны.\nНапример " +
                                "нет такой возможности как назначение иконок гизмо. Реализовать данный функционал не очень сложно," +
                                ", но пока нет на это времени", MessageType.Info);      
    }

    protected override void OnHeaderGUI()
    {
        EditorGUILayout.Space();
        OC = new ObjectControl(target);
        OC.Draw();
    }

    public override GUIContent GetPreviewTitle(){return GUIContent.none;}

    void OnSceneGUI()
    {
        windowRect = GUILayout.Window(0, windowRect, Win, target.name);

    }

    public void Win(int windowID)
    {
        var t = target as GameObject;
        if (t)
        {
            OC = new ObjectControl(target);
            OC.Draw();
        }
    }
}
