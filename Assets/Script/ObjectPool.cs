using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //オブジェクトのリスト
    private List<GameObject> _PoolObjList;

    [SerializeField]
    //実際に生成するオブジェクト
    private GameObject _PoolObj;

    public void CreatePool(GameObject obj ,int maxCount)
    {
        _PoolObj = obj;
        _PoolObjList = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newObj = CreateNewObject();
            newObj.SetActive(false);
            _PoolObjList.Add(newObj);
        }
    }

    public GameObject GetObject()
    {
        // 使用中でないものを探して返す
        foreach (GameObject obj in _PoolObjList)
        {
            if (!obj.activeSelf)
            {
                //使用中でないのならオブジェクトをアクティブにする
                obj.SetActive(true);
                return obj;
            }
        }
        // 全て使用中だったら新しく作って返す
        GameObject newObj = CreateNewObject();
        newObj.SetActive(true);
        _PoolObjList.Add(newObj);

        return newObj;
    }

    private GameObject CreateNewObject()
    {
        GameObject newObj = Instantiate(_PoolObj);
        newObj.name = _PoolObj.name + (_PoolObjList.Count + 1);
        newObj.transform.SetParent(gameObject.transform);

        return newObj;
    }
}
