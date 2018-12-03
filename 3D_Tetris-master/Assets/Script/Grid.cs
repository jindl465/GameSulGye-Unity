using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    //Store game score
    public static double gameScore = 0;
    public static double lastGameScore = 0;

    //initialize the width, length and height of the game area
    public static int w = 5;
    public static int l = 5;
    public static int h = 20;
    public static Transform[,,] grid = new Transform[w,h,l];

    //Store filled plane
    public static bool[] isFilled = new bool[h];

    //Help to round a vector
    public static Vector3 roundVec3 (Vector3 v)
    {
        return new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
    }

    //The insideBouder function, find out if a certain coordinate is in between
    //the bouders.
    public static bool insideBorder(Vector3 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < w
            && (int)pos.z >= 0 && (int)pos.z < l && (int)pos.y >= 0 && (int)pos.y < (h - 2));
    }
    
    //isPlaneFull function detects whether a plane is full. 
    //Find each cube's tag on plane y to find out 
    public static bool isPlaneFull(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            for (int z = 0; z < l; ++z)
            {
                if (grid[x, y, z] == null)
                    return false;
            }
        }
        return true;
    }

    //deleteFullRow function is the function that delete the full plane and drop the planes,
    //which are above the deleted plane.
    public static void checkFullPlane()
    {
        for (int y = 0; y < h; ++y)
        {
            if (isPlaneFull(y) && !isFilled[y])
            {
                gameScore += 5000;
                isFilled[y] = true;
            }
        }
    }
}
