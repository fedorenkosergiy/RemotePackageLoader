using System;
using System.Collections.Generic;
using UnityEngine;

namespace RemotePackageLoader.Editor
{
    [Serializable]
    public class Manifest
    {
        [SerializeField]
        private List<RemotePackageInfo> packages = new();

        public List<RemotePackageInfo> Packages => packages;
    }
}