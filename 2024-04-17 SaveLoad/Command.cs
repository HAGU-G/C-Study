using Newtonsoft.Json;
abstract class Command
{
    [JsonIgnore]
    public List<int> List { get; set; } = null;
    public int Number { get; set; } = 0;
    public abstract void Do();
    public abstract void Undo();
}


class CmdPushBack() : Command
{

    public override void Do()
    {
        List.Add(Number);
    }

    public override void Undo()
    {
        List.RemoveAt(List.Count - 1);
    }
}

class CmdPopBack() : Command
{
    public override void Do()
    {
        Number = List[List.Count - 1];
        List.RemoveAt(List.Count - 1);
    }

    public override void Undo()
    {
        List.Add(Number);
    }
}

class CmdPushFront() : Command
{
    public override void Do()
    {
        List.Insert(0, Number);
    }

    public override void Undo()
    {
        List.RemoveAt(0);
    }
}

class CmdPopFront() : Command
{
    public override void Do()
    {
        Number = List[0];
        List.RemoveAt(0);
    }

    public override void Undo()
    {
        List.Insert(0, Number);
    }
}