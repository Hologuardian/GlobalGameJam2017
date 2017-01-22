using System;
using System.Collections.Generic;

[Serializable]
public struct Tile
{
    public Tile(int x, int z, int id)
    {
        this.id = id;
        this.x = x;
        this.z = z;
    }

    int id;
    int x;
    int z;
}
