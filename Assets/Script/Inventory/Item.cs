using UnityEngine;

public class Item
{
    public string name;
    public Sprite icon;
    public int amount;

    public Item(string name, Sprite icon, int amount = 1)
    {
        this.name = name;
        this.icon = icon;
        this.amount = amount;
    }
}
