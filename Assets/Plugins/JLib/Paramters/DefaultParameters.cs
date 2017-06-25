﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// int bool float 등과 같은 기본 자료형을 사용하기 위한 파라미터이다.
/// 유니티의 스트럭쳐 Quaternion, Vector3도 만들어주자.
/// </summary>
namespace JLib
{
   [Serializable]
   public class SingleParameter<T>
    {
        public T value;
    }
}
