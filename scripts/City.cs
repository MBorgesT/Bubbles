using Godot;
using System;

public class City : Node
{

	bool textVisible;
	private const float STEP_SIZE = (float)2.5;

	public override void _Ready()
	{
		textVisible = false;
		Node2D textNode = GetNode<Node2D>("text-node");
		textNode.GetNode<Label>("text-area").Text = "teste testando";
	}

	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("ui_left") && !textVisible)
		{
			Sprite mainCharacter = GetNode<Sprite>("main-character-sprite");
			mainCharacter.Position += new Vector2(-STEP_SIZE, 0);
			mainCharacter.FlipH = true;
		}
		if (Input.IsActionPressed("ui_right") && !textVisible)
		{
			Sprite mainCharacter = GetNode<Sprite>("main-character-sprite");
			mainCharacter.Position += new Vector2(STEP_SIZE, 0);
			mainCharacter.FlipH = false;
		}
	}

	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("ui_select"))
		{
			Interactive npc = GetInteractibleInArea();
			if (npc != null && npc.Interactible) 
			{
				textVisible = !textVisible;
				Node2D textNode = GetNode<Node2D>("text-node");
				textNode.GetNode<Label>("text-area").Visible = textVisible;
				textNode.GetNode<Panel>("text-panel").Visible = textVisible;
			}
		}
	}

	private Interactive GetInteractibleInArea()
	{
		Vector2 currentPos = GetNode<Node2D>("main-character-sprite").Position;
		foreach (Node2D n in GetNode("interactives").GetChildren())
		{
			if (((Interactive)n).IsAtMyArea(currentPos)) {
				return (Interactive)n;
			}
		}
		return null;
	}

}
