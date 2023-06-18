using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Args
{
    public class IntegerArgs : EventArgs
    {
        public int amount;
    }
    public class TransformArgs : EventArgs 
    {
        public Transform transform;
    }
    public class GameObjectArgs : EventArgs
    {
        public GameObject gameObject;
    }
    public class BoolArgs : EventArgs
    {
        public bool value;
    }
}
