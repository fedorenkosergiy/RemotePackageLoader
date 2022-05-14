using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using RemotePackageLoader.Editor;
using RemotePackageLoader.Editor.Abstract;
using Unity.Serialization.Json;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

[InitializeOnLoad]
public class Startup {
    
    
    static Startup()
    {
        return;
        Do();
    }
    
    [MenuItem("startup/do")]
    public static void Do()
    {
        DefaultRemotePackageInfo info = new DefaultRemotePackageInfo();
        info.LocalPath = "a";
        info.RemotePath = "b";
        FileInfo fi = new FileInfo("test.json");
        List<IJsonMigration> migrations = new List<IJsonMigration>
        {
            new DefaultRemotePackageInfoMigration()
        };
        JsonSerializationParameters serializationParameters = new JsonSerializationParameters
        {
            UserDefinedMigrations = migrations
        };
        string json = JsonSerialization.ToJson(info, serializationParameters);

        DefaultRemotePackageInfo copy = new DefaultRemotePackageInfo();
        
        JsonSerialization.FromJsonOverride(json, ref copy, serializationParameters);

        return;
        Debug.Log("plugin 2");
        ListRequest q = Client.List();
        int j = 0;
        while (!q.IsCompleted && j < 100)
        {
            Thread.Sleep(1000);
            j++;
        }

        PackageCollection result = q.Result;
        for (int i = 0; i < result.Count(); ++i)
        {
            Debug.Log(result.ToArray()[i].name);
        }
        
    }
}
