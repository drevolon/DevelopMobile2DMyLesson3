using System;
using System.Collections.Generic;

public interface IInventoryView
{
    event EventHandler<IItem> Selected;
    event EventHandler<IItem> Deselected;
    void Display(List<IItem> items);
    void Display(IReadOnlyList<IItem> items);
}