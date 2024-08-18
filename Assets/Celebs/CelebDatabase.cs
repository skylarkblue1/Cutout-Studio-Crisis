using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CelebDatabase : MonoBehaviour
{
    public Celebs[] items = new Celebs[7];
}

[Serializable]
public class Celebs
{
    public String firstName;
    public String lastName;
    public float height;
    public String eyes;
    public String hair;
}
