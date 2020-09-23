/*---------------------------------------------
 *
 * Title: 资源/对象池静态管理工厂
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
using System;
using UnityEngine;
using UnityEngine.UI;
namespace GameFramwork
{
    public class AssetsManager:Singleton<AssetsManager>,IResourceInterface
    {
        private IResourceInterface  mResource = null;
        public IResourceInterface Resource { set { mResource = value; } }

        public void PreLoadObj(string path, int count = 1, bool clear = false)
        {
            mResource.PreLoadObj(path, count, clear);
        }
        public void PreLoadRes(string path)
        {
            mResource.PreLoadRes(path);
        }
        public GameObject InstansObj(string path, Transform parent = null, bool LocalPosIsZroe = true, bool localScaleIsOne = true, bool bClear = true)
        {
           return  mResource.InstansObj(path,parent,LocalPosIsZroe,localScaleIsOne,bClear);
        }
        public void InstansObjAsync(string path, Action<GameObject> asyncCall, LoadResPriority priority, bool setSceneObject = false, object param1 = null)
        {
            mResource.InstansObjAsync(path, asyncCall, priority, setSceneObject, param1);
        }
        public GameObject LoadView(string viewName)
        {
            return mResource.LoadView(viewName);
        }
        public Sprite LoadSprite(string path)
        {
            return mResource.LoadSprite(path);
        }
        public Sprite LoadAtlasSprite(string atlaspath, string spritename)
        {
            return mResource.LoadAtlasSprite(atlaspath,spritename);
        }
        public Texture LoadTexture(string path)
        {
            return mResource.LoadTexture(path);
        }
        public TextAsset LoadTextAsset(string path)
        {
            return mResource.LoadTextAsset(path);
        }
        public byte[] LoadBytes(string path)
        {
            return mResource.LoadBytes(path);
        }
        public AudioClip LoadAudio(string path)
        {
            return mResource.LoadAudio(path);
        }
        public void LoadSpriteAsync(string path, Image image, bool setNativeSize = false)
        {
           mResource.LoadSpriteAsync(path,image,setNativeSize);
        }
        public void LoadTextureAsync(string path, Action<Texture> asyncCall)
        {
            mResource.LoadTextureAsync(path, asyncCall);
        }
        public void CleraObjectPool(string path)
        {
            mResource.CleraObjectPool(path);
        }
        public void CleraPool()
        {
            mResource.CleraPool();
        }
        public void ReleaseObj(GameObject obj, bool destoryCache = false, int maxCacheCount = -1, bool recycleParent = true)
        {
            mResource.ReleaseObj(obj,destoryCache,maxCacheCount,recycleParent);
        }

        ///使用实例 ClassObjectPool<LoginWindow> classObject= ObjectManager.Instance.GetOrCreatClassPool<LoginWindow>(200);        classObject.Spawn();//取对象    classObject.Recycle();//回收
        /// <summary>
        /// 创建类对象池，创建完成以后外面可以保存ClassObjectPool<T>,然后调用Spawn和Recycle来创建和回收类对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="num"></param>
        /// <returns></returns>
        public ClassObjectPool<T> GetOrCreateClassPool<T>(int num) where T : class, new()
        {
            return ObjectManager.Instance.GetOrCreatClassPool<T>(num);
        }
    }
}