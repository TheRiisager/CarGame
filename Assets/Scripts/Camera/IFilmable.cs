using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFilmable
{
    abstract event Action<float> VelocityEvent;
}
