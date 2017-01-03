using System;
using System.Reflection;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class AutoFind : Attribute
{
	public enum Mode
	{
		Local, World
	}

	byte type;
	string hierachy;
	Mode mode;

	public AutoFind()
	{
		type = 0;
	}

	public AutoFind(string hierachy)
	{
		type = 1;
		this.hierachy = hierachy;
	}

	public AutoFind(string hierachy, Mode mode)
	{
		type = 2;
		this.hierachy = hierachy;
		this.mode = mode;
	}

	public void Execute(AutofindBehaviour autofindBehaviour, FieldInfo field)
	{
		if (type == 0)
		{
			field.SetValue(autofindBehaviour, autofindBehaviour.transform.GetComponent(field.GetValue(autofindBehaviour).GetType()));
		}
		else if (type == 1)
		{
			field.SetValue(autofindBehaviour, autofindBehaviour.transform.FindChild(hierachy).GetComponent(field.GetValue(autofindBehaviour).GetType()));
		}
		else if (type == 2)
		{
			if (mode == Mode.Local)
			{
				field.SetValue(autofindBehaviour, autofindBehaviour.transform.FindChild(hierachy).GetComponent(field.GetValue(autofindBehaviour).GetType()));
			}
			else
			{
				field.SetValue(autofindBehaviour, GameObject.Find(hierachy).GetComponent(field.GetValue(autofindBehaviour).GetType()));
			}
		}
	}
}