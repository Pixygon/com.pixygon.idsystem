using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pixygon.ID {
    [Serializable]
    public class IdCategoryList {
        public string _groupName;
        public int _groupId;
        public List<IdObject> _list;

        public IdObject GetObject(int id) {
            if (id == 0) return null;
            var obj = (from d in _list where d.Id == id select d).FirstOrDefault();
            if(obj == null) Debug.Log("IdObject " + id + " is null!");
            return obj;
        }

        public IdObject[] GetArray()
        {
            return _list.ToArray();
        }
    }
}