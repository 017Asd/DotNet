using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cart = new Cart();
        var manager = new CommandManager();

        manager.Execute(new AddItemCommand(cart, "Pen"));
        manager.Execute(new AddItemCommand(cart, "Book"));

        manager.Undo();
        manager.Redo();

        Console.WriteLine(string.Join(",", cart.Items));
    }
}

interface ICommand
{
    void Execute();
    void Undo();
}

class Cart
{
    public List<string> Items = new();
}

class AddItemCommand : ICommand
{
    private readonly Cart _cart;
    private readonly string _item;

    public AddItemCommand(Cart cart, string item)
    {
        _cart = cart;
        _item = item;
    }

    public void Execute() => _cart.Items.Add(_item);
    public void Undo() => _cart.Items.Remove(_item);
}

class CommandManager
{
    private readonly Stack<ICommand> undo = new();
    private readonly Stack<ICommand> redo = new();

    public void Execute(ICommand cmd)
    {
        cmd.Execute();
        undo.Push(cmd);
        redo.Clear();
    }

    public void Undo()
    {
        if (!undo.Any()) return;
        var cmd = undo.Pop();
        cmd.Undo();
        redo.Push(cmd);
    }

    public void Redo()
    {
        if (!redo.Any()) return;
        var cmd = redo.Pop();
        cmd.Execute();
        undo.Push(cmd);
    }
}
