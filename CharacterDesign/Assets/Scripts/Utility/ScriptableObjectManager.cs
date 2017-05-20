using System.IO;
using UnityEditor;
using UnityEngine;

namespace Spacefarer.Utility
{
    public static class ScriptableObjectManager {
        public static void CreateAsset<T>() where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            ProjectWindowUtil.CreateAsset(asset, "New " +typeof(T).Name + ".asset");
        }
        public static void CreateAsset<T>(string fileLocation, string fileName) where T : ScriptableObject
        {
            CreateAsset<T>(Path.Combine(fileLocation, fileName + ".asset"));
        }
        public static void CreateAsset<T>(string path) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public static T LoadDatabase<T>(string path) where T : ScriptableObject
        {
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }
        //public static T LoadAsset<T>(string fileLocation, string fileName) where T : ScriptableObject
        //{
        //    return LoadAsset<T>(Path.Combine(fileLocation, fileName + ".asset"));
        //}
        [MenuItem("Assets / Create / Database")]
        public static void CreateYourScriptableObject()
        {
            CreateAsset<Database>();
        }
    }
}

