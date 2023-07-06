using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectPoolCollection;
    [SerializeField] private int objectPoolAmount;
    [SerializeField] private GameObject objectPrefab;

    private void Start()
    {
        InitializeObjectPool();
    }

    public void InitializeObjectPool()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        objectPoolCollection.Clear();
        InstantiateObjects();
    }

    private void InstantiateObjects()
    {
        GameObject newObject = null;
        Transform targetParent = transform;

        for (int i = 0; i < objectPoolAmount; i++)
        {
            if (newObject == null)
            {
                newObject = Instantiate(objectPrefab);
                newObject.name = $"{objectPrefab.name}-{i}";
                newObject.transform.SetParent(targetParent);
            }
            else
            {
                newObject = Instantiate(newObject, targetParent);
                newObject.name = $"{objectPrefab.name}-{i}";
            }
            objectPoolCollection.Add(newObject);
            newObject.SetActive(false);
        }
    }

    public void ActivateValidObject(Vector3 position, Quaternion rotation)
    {
        bool isAnObjectActivated = false;
        for (int i = 0; i < objectPoolCollection.Count; i++)
        {
            if (!objectPoolCollection[i].activeInHierarchy)
            {
                objectPoolCollection[i].transform.SetPositionAndRotation(position, rotation);
                objectPoolCollection[i].SetActive(true);
                isAnObjectActivated = true;
                break;
            }
        }

        if (!isAnObjectActivated)
        {
            Debug.Log("No Object Available");
        }
    }
}
