using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Building
{
    public int minHeight;
    public int maxHeight;
    public List<GameObject> parts;
}