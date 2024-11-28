
using System.Collections.Generic;
using System.Linq;

namespace ThemedCult;

public static class Extensions
{
    public static GameObject FindChild(this GameObject @object, string objectName)
    {
        var objects = @object.GetChildren();

        foreach (var gameObject in objects)
        {
            if (gameObject.name != objectName)
                continue;
                
            LogInfo($"found object with name {objectName} in children of {@object.name}!");
            return gameObject.gameObject;
        }
        LogInfo($"Couldn't find object with name {objectName} in children of {@object.name}!");
        return null;
    }

    public static List<GameObject> GetChildren(this GameObject @object)
    {
        if(@object.transform.childCount == 0)
            return new List<GameObject>();

        List<GameObject> children = [];
        
        foreach(Transform obj in @object.transform)
            children.Add(obj.gameObject);
        
        foreach (var obj in children.ToList())
        {
            var kids = obj.GetChildren();
            children.AddRange(kids);
        }
        
        return children;
    }
}