using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutofindTest : AutofindBehaviour
{
    [AutoFind]
    public Rigidbody rigidbody;

    [AutoFind("SphereTop")]
    public SphereCollider sphereCollider;

    [AutoFind("Directional Light", AutoFind.Mode.World)]
    public Light sun;
}
