
using UnityEngine;
using UnityEngine.UI;
/*---------------------------------------------
 *
 * Title: 资源/对象池加载接口管理
 *
 * Description: 类对象池/资源对象池/替换图片的封装类，所有路径都基于Assets开始
 *
 * Author: YYCM
 *
 * Date: 2019.8.29
 *
 * Modify: 
 * 
------------------------------------------------*/
public class AssetsLoader : IResourceInterface
{
    public void PreLoadObj(string path, int count = 1, bool clear = false)
    {
        ObjectManager.Instance.PreloadGameObject(path, count, clear);
    }

    public void PreLoadRes(string path)
    {
        ResourceManager.Instance.PreLoadRes(path);
    }

    public GameObject InstansObj(string path, Transform parent = null, bool LocalPosIsZroe = true, bool localScaleIsOne = true, bool bClear = true)
    {
        return ObjectManager.Instance.InstantiateObject(path, parent, LocalPosIsZroe, localScaleIsOne, bClear);
    }

    public void InstansObjAsync(string path, System.Action<GameObject> asyncCall, LoadResPriority priority, bool setSceneObject = false, object param1 = null)
    {
        ObjectManager.Instance.InstantiateObjectAsync(path, OnInstansObjFinsh, priority, setSceneObject, asyncCall);
    }

    private void OnInstansObjFinsh(string path, Object obj, object param1 = null, object param2 = null, object param3 = null)
    {
        if (obj!=null)
        {
            System.Action<GameObject> action = (System.Action<GameObject>)param1;
            action?.Invoke(obj as GameObject);
        }
    }
    public Sprite LoadAtlasSprite(string atlaspath, string spritename)
    {
        return ResourceManager.Instance.LoadAtlasSprite(atlaspath,spritename);
    }
    public AudioClip LoadAudio(string path)
    {
        return ResourceManager.Instance.LoadResource<AudioClip>(path);
    }
    public byte[] LoadBytes(string path)
    {
        return System.Text.Encoding.UTF8.GetBytes(ResourceManager.Instance.LoadResource<TextAsset>(path).text);
    }

    public Sprite LoadSprite(string path)
    {
       return  ResourceManager.Instance.LoadResource<Sprite>(path);
    }

    public TextAsset LoadTextAsset(string path)
    {
        return ResourceManager.Instance.LoadResource<TextAsset>(path);
    }

    public Texture LoadTexture(string path)
    {
       return  ResourceManager.Instance.LoadResource<Texture>(path);
    }

    public GameObject LoadView(string path)
    {
        return ObjectManager.Instance.InstantiateView(path);
    }

    public void LoadSpriteAsync(string path, Image image, bool setNativeSize = false)
    {
        ResourceManager.Instance.AsyncLoadResource(path, OnLoadSpriteFinish, LoadResPriority.RES_MIDDLE, true, image, setNativeSize);
    }
    private void OnLoadSpriteFinish(string path, Object obj, object param1 = null, object param2 = null, object param3 = null)
    {
        if (obj != null)
        {
            Sprite sp = obj as Sprite;
            Image image = param1 as Image;
            bool setNativeSize = (bool)param2;
            if (image.sprite != null)
                image.sprite = null;

            image.sprite = sp;
            if (setNativeSize)
            {
                image.SetNativeSize();
            }
        }
    }

    public void LoadTextureAsync(string path, System. Action<Texture> asyncCall)
    {
        ResourceManager.Instance.AsyncLoadResource(path, OnLoadTextureFinish, LoadResPriority.RES_MIDDLE, false, asyncCall);
    }
    private void OnLoadTextureFinish(string path, Object obj, object param1 = null, object param2 = null, object param3 = null)
    {
        if (obj != null)
        {
            System.Action<Texture> action = (System.Action<Texture>)param1;
            action?.Invoke(obj as Texture);
        }
    }

    public void ReleaseObj(GameObject obj, bool destoryCache = false, int maxCacheCount = -1, bool recycleParent = true)
    {
        ObjectManager.Instance.ReleaseObject(obj, destoryCache, maxCacheCount, recycleParent);
    }

    public void CleraObjectPool(string path)
    {
        if (string.IsNullOrEmpty(path)) return;
        uint crc = Crc32.GetCrc32(path);
        ObjectManager.Instance.ClearPoolObject(crc);
    }

    public void CleraPool()
    {
        ObjectManager.Instance.ClearCache();
    }
}
