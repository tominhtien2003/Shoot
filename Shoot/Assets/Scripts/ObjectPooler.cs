using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public Transform prefab;
        public int size;
    }

    [SerializeField] private List<Pool> pools = new List<Pool>();
    [SerializeField] private Dictionary<string, Queue<Transform>> objectPoolDictionary = new Dictionary<string, Queue<Transform>>();

    private void Start()
    {
        foreach (Pool pool  in pools)
        {
            Queue<Transform> queue = new Queue<Transform> ();
            for (int i=0;i<pool.size;i++)
            {
                Transform obj = Instantiate(pool.prefab);
                obj.gameObject.SetActive(false);
                queue.Enqueue(obj);
            }
            objectPoolDictionary.Add(pool.tag, queue);
        }
    }
    public Transform SpawnObject(string tag,Vector3 position, Quaternion rotation)
    {
        if (!objectPoolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Don't have object with tag : " + tag);
            return null;
        }
        Transform obj = objectPoolDictionary[tag].Dequeue();
        if (!obj.gameObject.activeInHierarchy)
        {
            obj.gameObject.SetActive(true);
            obj.position = position;
            obj.rotation = rotation;

        }
        objectPoolDictionary[tag].Enqueue(obj);
        return obj;
    }
}
