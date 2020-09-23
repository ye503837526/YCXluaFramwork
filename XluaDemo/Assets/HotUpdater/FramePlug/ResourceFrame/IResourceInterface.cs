using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IResourceInterface
{
     void PreLoadObj(string path, int count = 1, bool clear = false);
     void PreLoadRes(string path);
     TextAsset LoadTextAsset(string  path);
    AudioClip LoadAudio(string path);
     byte[] LoadBytes(string path);
     Sprite LoadSprite(string path);
     Sprite LoadAtlasSprite(string  atlaspath,string spritename);
     Texture LoadTexture(string path);
     GameObject LoadView(string viewName);
     GameObject InstansObj(string path,Transform parent=null, bool LocalPosIsZroe = true, bool localScaleIsOne = true, bool bClear = true);
    void InstansObjAsync(string path, Action<GameObject> asyncCall, LoadResPriority priority, bool setSceneObject = false, object param1 = null);
    void LoadSpriteAsync(string path, Image image, bool setNativeSize = false);
    void LoadTextureAsync(string path,Action<Texture> asyncCall);
    void ReleaseObj(GameObject obj, bool destoryCache = false, int maxCacheCount = -1, bool recycleParent = true);
    void CleraObjectPool(string path);
    void CleraPool();
}
