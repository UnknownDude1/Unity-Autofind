# Unity Autofind

A simple attribute to add to your variables.

# What does it do?
It automatically assigns the component to the variable the attribute is at.
Basically, it automatically does the job that transform.FindChild("...").GetComponent(...); does in the Awake() method.

# How do I use it?
The attribute has 3 versions:

1) The version to find components directly on the GameObject

2) The version to find components in children

3) The version to find components on GameObjects in the scene

There is one important thing that applies to <b>all</b> versions of the attribute: The script that you are using it in has to extend AutofindBehaviour instead of MonoBehaviour, because it has a special version of Awake(). If you want to use the Awake() method in you own code, make sure to override it correctly and add a base.Awake(); in the first line in the method.

# 1)
You simply add the attribute above a field that is the type of a component. It will automatically assign the searched component in the Awake() method.

<b>Sample Code</b>
```
public class Test : AutofindBehaviour
{
  [AutoFind]
  public Camera mainCamera;
}
```


# 2)
This works essentially like the first version, just that you also add a string like you would do in transform.FindChild("..."). It will automatically assign the searched component from the given child in the Awake() method.

<b>Sample Code</b>
```
public class Test : AutofindBehaviour
{
  [AutoFind("UI Camera")]
  public Camera uiCamera;
}
```

# 3)
This one is a bit special. It automatically searches for a matching GameObject in the scene, the job that GameObject.Find("...") does. It will automatically assign the searched component from the given GameObject in the scene in the Awake() method.

<b>Sample Code</b>
```
public class Test : AutofindBehaviour
{
  [AutoFind("Directional Light", AutoFind.Mode.World)]
  public Light sun;
}
```
