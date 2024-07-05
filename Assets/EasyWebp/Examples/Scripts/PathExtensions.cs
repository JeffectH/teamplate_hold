using System;
using System.Collections;

namespace UnityEngine
{
    public static class PathExtensions
    {
        public static string StreamingAssetsPath()
        {
            string path = null;
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    path = "file://" + Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.OSXEditor:
                    path = "file://" + Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.WindowsPlayer:
                    path = "file://" + Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.OSXPlayer:
                    path = "file://" + Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.WebGLPlayer:
                    path = Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    path = "file://" + Application.streamingAssetsPath;
                    break;
                case RuntimePlatform.Android:
                    path = "jar:file://" + Application.dataPath + "!/assets";
                    break;
            }
            return path;
        }
    }
}