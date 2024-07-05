using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class LoadingScene : MonoBehaviour
{
    public Button m_Bt_Next;
    public Button m_Bt_Last;

    public static int currentSceneIndex = 0;

    private void Awake()
    {
#if UNITY_EDITOR
        string oStreamingAssets = Application.dataPath + "/EasyWebp/StreamingAssets";
        string StreamingAssetsDirectory = Application.dataPath + "/StreamingAssets";
        if (Directory.Exists(oStreamingAssets) && !Directory.Exists(StreamingAssetsDirectory))
        {
            Directory.Move(oStreamingAssets, StreamingAssetsDirectory);
            string oStreamingAssetsMeta = oStreamingAssets + ".meta";
            if (File.Exists(oStreamingAssetsMeta))
                File.Delete(oStreamingAssetsMeta);
        }
#endif
    }

    void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        m_Bt_Next.onClick.AddListener(() =>
        {
            currentSceneIndex++;
            if (currentSceneIndex > sceneCount - 1)
                currentSceneIndex = 0;
            SceneManager.LoadScene(currentSceneIndex);
        });
        m_Bt_Last.onClick.AddListener(() =>
        {
            currentSceneIndex--;
            if (currentSceneIndex < 0)
                currentSceneIndex = sceneCount - 1;
            SceneManager.LoadScene(currentSceneIndex);
        });
    }
}
