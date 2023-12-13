using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static GameObject FindObjectByName(string name)
    {
        GameObject[] objs = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objs)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }
}
