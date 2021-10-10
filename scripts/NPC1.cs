using Godot;
using System;

public class NPC1 : Interactive
{
    public override void _Ready()
    {
        MAX_DISTANCE = (float)40;
        Text = "HEY MAN...DO YA HAVE ANY SPARE CHANGES? I NEED TO BUY SOME FOOD.";
    }

}
