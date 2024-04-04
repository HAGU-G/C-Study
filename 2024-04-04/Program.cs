TextBox r = new TextBox();
r.Undo();                 // RichTextBox.Undo      Case 1
((IUndoable)r).Undo();    // RichTextBox.Undo      Case 2





public interface IUndoable { public void Undo(); }

public class TextBox : IUndoable
{
    public void Undo() => Console.WriteLine("TextBox.Undo"); // explicitly, virtual
}

public class RichTextBox : TextBox, IUndoable
{
    public void Undo() => Console.WriteLine("RichTextBox.Undo");
}