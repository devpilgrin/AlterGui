using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

//Использование UserControl В редакторах диаграм
public class GraphEditorWindow : EditorWindow
{
    public ObjectControl objectControl;
 
    public List<Rect> windowsList = new List<Rect>();

    // Add menu item to the Window menu
	[MenuItem ("Window/Graph Editor Window")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		GetWindow<GraphEditorWindow> (false, "Graph Editor Window");
	}

    private void OnGUI()
    {
        if (windowsList.Count==0)



        SetCollections();


        for (int i = 0; i < windowsList.Count; i++)
        {
            if((i+1)<windowsList.Count)
            DrawBezier( windowsList[i],windowsList[i+1]);
        }

        BeginWindows();

        for (int index = 0; index < windowsList.Count; index++)
        {
            windowsList[index] = GUILayout.Window(index + 2, windowsList[index], WindowFunction, "Graph Window");
        }
        
        EndWindows();
    }

    private void DrawBezier(Rect _windowRect, Rect _windowRect2)
    {
        Handles.BeginGUI();
        Handles.DrawBezier(
            new Vector2(_windowRect.x + _windowRect.width, _windowRect.y + 20),
            new Vector2(_windowRect2.x, _windowRect2.y + 20),
            new Vector2(_windowRect.xMax + 20, _windowRect.y + 20),
            new Vector2(_windowRect2.xMin - 20, _windowRect2.y + 20),
            Color.red, null, 3f);
        Handles.EndGUI();
    }

    void WindowFunction(int windowID)
    {
        objectControl = new ObjectControl(Selection.activeGameObject);
        objectControl.Draw();

        GUI.DragWindow();
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

    //заполняем коллекции
    private void SetCollections()
    {
        
        windowsList.Clear();


        for (int index = 0; index < 2; index++)
            {
                windowsList.Add(new Rect(index *100, (index * 30) + 10, 10, 10));
            }

    }

}