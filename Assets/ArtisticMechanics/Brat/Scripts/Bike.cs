using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour {

	public void ChangeLean(float x = 0, float y = 0, float z = 0)
    {
        GameObject obj = GameObject.Find("Brat Stand up Set");
        obj.transform.Rotate(x, y, z);
    }
}
