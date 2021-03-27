using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnButton : MonoBehaviour
{
    public GameObject[] buttons;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    public void ThreeRandomFromArray<T>(T[] array, out T out0, out T out1, out T out2 )
    {
        if(array.Length < 3)
        {
            throw new System.Exception("The array is not big enough to pick 3 random objects");
        }

        T cached0 = RandomFromArray(array);
        T cached1;
        T cached2;

    GetSecond: cached1 = RandomFromArray(array);

        if (cached1.Equals(cached0))
        {
            goto GetSecond;
        }
    GetThird: cached2 = RandomFromArray(array);

        if (cached2.Equals(cached0) || cached2.Equals(cached1))
        {
            goto GetThird;
        }

        out0 = cached0;
        out1 = cached1;
        out2 = cached2;
    }

    private T RandomFromArray<T>(T[] list)
    {
        return list[Random.Range(0, list.Length)];
    }

    private void Start()
    {
        GameObject object0;
        GameObject object1;
        GameObject object2;

        //Run the function and actually assign the previously declared gameobjects
        ThreeRandomFromArray(buttons, out object0, out object1, out object2);

        //Create object0, object1, object2 at thei corresponding spawn position
        Instantiate(object0, spawnPoint1.transform);
        Instantiate(object1, spawnPoint2.transform);
        Instantiate(object2, spawnPoint3.transform);
    }
}
