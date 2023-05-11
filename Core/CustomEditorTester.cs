using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomEditorShowcase : MonoBehaviour // Showcase for CustomEditorBase.cs (unused now)
{
    public int aNumber;
    public int AFloat;
    [Range(0f, 100f)]
    public float AFloatRangeAttr;
    public string aString;

    public int[] aNumerArray;
    public float[] aFloatArray;
    [Range(0.0f, 100.0f)]
    public float[] anotherFloatArray;

    [SerializeField]
    private List<Stuff> privateListOfStuff;

    [SerializeField]
    private SomeOtherData NestedData;

    //[SerializeField]
    //private EventReference mixerClip;

    //[SerializeField]
    //private EventReference[] mixerClips;
}

[System.Flags]
public enum Stuff
{
    Coke = 1 << 0,
    Hamburguer = 1 << 1,
    Pizza = 1 << 2,
    Hotdog = 1 << 3,
    Pepsi = 1 << 4,
    Beer = 1 << 5,
    BuffaloWings = 1 << 6,
    IceCream = 1 << 7,

}

[System.Serializable]
public struct SomeOtherData
{
    public int aNumber;
    [Range(0f, 1f)]
    public float anotherNumber;
    public Vector3 position;
}
