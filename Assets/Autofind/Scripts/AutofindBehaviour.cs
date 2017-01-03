using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AutofindBehaviour : MonoBehaviour
{
	protected virtual void Awake()
	{
		List<FieldInfo> fields = GetType().GetFields().Where(prop => Attribute.IsDefined(prop, typeof(AutoFind))).ToList();

		for (int i = 0; i < fields.Count; i++)
		{
			foreach (AutoFind autofind in fields[i].GetCustomAttributes(typeof(AutoFind), true))
			{
				autofind.Execute(this, fields[i]);
			}
		}
	}
}