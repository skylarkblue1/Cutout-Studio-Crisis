using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CelebDatabase : MonoBehaviour
{
    public Celebs[] items = new Celebs[2];
}

[Serializable]
public class Celebs
{
    public String firstName;
    public String lastName;
    public String height;
    public String eyes;
    public String hair;
}
