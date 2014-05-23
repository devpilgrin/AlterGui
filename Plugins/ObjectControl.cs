using UnityEditor;
using UnityEngine;

public class ObjectControl : UserControl
{
    private GameObject obj;

    public GameObject Obj
    {
        get { return obj; }
        set { obj = value; }
    }

    public ObjectControl(Object _obj)
    {
        obj = _obj as GameObject;
    }

    public override void Draw()
    {
        EditorGUILayout.BeginVertical(PanelBorder.HelpBox.ToString());

        EditorGUILayout.BeginHorizontal();

        if (obj)
        {
            if (obj.isStatic) GUI.backgroundColor = Color.cyan;
            EditorGUILayout.LabelField(new GUIContent(EditorGUIUtility.ObjectContent(null, obj.GetType()).image), GUILayout.Width(20),GUILayout.Height(20));
        }
        obj = (GameObject) EditorGUILayout.ObjectField("", obj, typeof (GameObject), true);
        EditorGUILayout.EndHorizontal();
        
        if (obj)
        {
            
            EditorGUILayout.BeginVertical(PanelBorder.HelpBox.ToString());
            EditorGUILayout.BeginHorizontal();



            EditorGUILayout.LabelField(new GUIContent("Tag: ", "Game object tag"), GUILayout.Width(40));
            obj.tag = EditorGUILayout.TagField(obj.tag);

            EditorGUILayout.LabelField(new GUIContent("Layer: ", "Game object layer"), GUILayout.Width(40));
            obj.layer = EditorGUILayout.LayerField(obj.layer);

            EditorGUILayout.LabelField(new GUIContent("Static: ", "Game object static"), GUILayout.Width(40));
            obj.isStatic = EditorGUILayout.Toggle(obj.isStatic, GUILayout.Width(20));



            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();


        }

        GUI.backgroundColor = Color.white;
        EditorGUILayout.EndVertical();
    }
}