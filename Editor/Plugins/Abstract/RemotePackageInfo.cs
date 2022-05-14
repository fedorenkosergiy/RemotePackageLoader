using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RemotePackageLoader.Editor.Abstract
{
    public interface RemotePackageInfo
    {
        string RemotePath { get; }
        string LocalPath { get; }
    }
}