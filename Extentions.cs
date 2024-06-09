using System;
using System.Collections.Generic;
using System.Text;

namespace ThemedCult
{
    public static class Extentions
    {
        public static GameObject FindChild(this GameObject @object, string objectName)
        {
            Transform[] transforms = @object.GetComponentsInChildren<Transform>();

            foreach (Transform transform in transforms)
            {
                if (transform.gameObject.name == objectName)
                {
                    LogInfo($"found object with name {objectName} in children of {@object.name}!");
                    return transform.gameObject;
                }
            }
            LogInfo($"Couldn't find object with name {objectName} in children of {@object.name}!");
            return null;
        }
    }
}
