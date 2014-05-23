using UnityEngine;

public sealed class ButtonControl : UserControl
{
    private bool state;
    private string text;

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    public event Clic MyEvent;

    public ButtonControl(string _name,string _text)
    {
        Name = _name;
        text = _text;
    }

    public override void Draw()
    {
        if (!visible) return;
        if (!GUILayout.Button(text)) return;
        if (MyEvent == null) return;
        MyEvent(this, null);
    }
}