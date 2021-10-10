using Godot;
using System;

public class Interactive : Node2D
{

    protected float MAX_DISTANCE = (float)44;

    public string Text;

    public bool Interactible = true;
    
    public bool IsAtMyArea(Vector2 mainCharacterPos) {
        return this.Position.DistanceTo(mainCharacterPos) < MAX_DISTANCE;
    }

}