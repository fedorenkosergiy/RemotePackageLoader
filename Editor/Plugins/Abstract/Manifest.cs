using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RemotePackageLoader.Editor.Abstract
{
    public interface Manifest
    {
        RemotePackageInfo[] Packages { get; }
    }
}