using System.Linq;
using UnityEngine;
using UnityEditor;

public class Example : EditorWindow
{
    public static PanelControl panel = new PanelControl();
    public static readonly ObjectControl GoControl = new ObjectControl(null);


	// Add menu item to the Window menu
	[MenuItem ("Window/Example Control")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		GetWindow<Example> (false, "Example");
	}
	
	// Implement your own editor GUI here.
	void OnGUI ()
	{
	    if (panel.ChildUserControls.Count == 0)
	    {
	        panel = new PanelControl();
            panel.AddControl(new HorizontalHeaderControl("Тестовый набор инструментов"));
            panel.AddControl(GoControl);
            panel.AddControl(new ButtonControl("Button_0", "Сбросить имя"));
	        panel.AddControl(new ButtonControl("Button_1", "В начальную точку координат"));

	        panel.AddControl(new ButtonControl("Button_3", "Нажми меня"));

	        var move_up_Panel = new PanelControl();

            move_up_Panel.AddControl(new HorizontalHeaderControl("Перемещение объекта по оси Y"));
            
	        var HPanel = new Panel_HorizontalControl(PanelBorder.HelpBox);
	        HPanel.AddRangeControls(new UserControl[]
	        {
                new ButtonControl("move_up_Button", 1.ToString()), new ButtonControl("move_up_Button", 2.ToString()),
	            new ButtonControl("move_up_Button", 3.ToString()), new ButtonControl("move_up_Button", 4.ToString()),
                new ButtonControl("move_up_Button", 5.ToString()), new ButtonControl("move_up_Button", 6.ToString()),
	            new ButtonControl("move_up_Button", 7.ToString()), new ButtonControl("move_up_Button", 8.ToString()),
                new ButtonControl("move_up_Button", 9.ToString()), new ButtonControl("move_up_Button", 10.ToString())
	        });

            foreach (var userC in HPanel.ChildUserControls.OfType<ButtonControl>().Select(control => control))
	        {
	            userC.MyEvent += ButtonClic;
	        }

            move_up_Panel.AddControl(HPanel);

            panel.AddControl(move_up_Panel);
            
	        foreach (var userC in panel.ChildUserControls.OfType<ButtonControl>().Select(control => control))
	        {
	            userC.MyEvent += ButtonClic;
	        }
	    }

	    panel.Draw();	
    }

    /// <summary>
    /// Обработка события нажатия кнопок
    /// </summary>
    /// <param name="sender">Нажатая кнопка</param>
    /// <param name="args">Аргументы</param>
    private static void ButtonClic(object sender, UserControl args)
    {   
        var se = sender as ButtonControl;
        if (se != null)
        {
            Debug.Log("Нажата кнопка " + se.Name);
            if (GoControl.Obj)
            {
                if (se.Name == "Button_0")
                {
                    GoControl.Obj.name = GoControl.Obj.GetType().Name;
                }
                if (se.Name == "Button_1") GoControl.Obj.transform.position = Vector3.zero;
                if (se.Name == "move_up_Button") GoControl.Obj.transform.position = new Vector3(GoControl.Obj.transform.position.x,
                            GoControl.Obj.transform.position.y + int.Parse(se.Text),
                            GoControl.Obj.transform.position.z);

            }

        }
    }


    // Called whenever the selection has changed.
    private void OnSelectionChange()
    {
        GoControl.Obj = Selection.activeGameObject;
    }

    // Called whenever the scene hierarchy
    // has changed.
    private void OnHierarchyChange()
    {
        GoControl.Obj = Selection.activeGameObject;
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

}