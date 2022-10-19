using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pixygon.ID {
    [CreateAssetMenu(fileName = "New ID Group", menuName = "Pixygon/ID/New ID Group")]
    public class IdGroup : ScriptableObject
    {
        public List<IdCategoryList> _categories;

        public IdCategoryList GetCategory(int categoryId) {
            var cat = (from d in _categories where d._groupId == categoryId select d).FirstOrDefault();
            if(cat == null) Debug.Log("Category " + categoryId + " is null!");
            return cat;
        }
        public IdCategoryList GetCategory(string categoryId) {
            var cat = (from d in _categories where d._groupName == categoryId select d).FirstOrDefault();
            if(cat == null) Debug.Log("Category " + categoryId + " is null!");
            return cat;
        }
        public IdObject GetObject(int categoryId, int id) {
            var cat = (from d in _categories where d._groupId == categoryId select d).FirstOrDefault()?._list;
            if(cat == null) Debug.Log("Category " + categoryId + " is null!");
            var obj = (from g in cat where g.Id == id select g).FirstOrDefault();
            if(obj == null) Debug.Log("IdObject " + id + " is null!");
            return obj;
        }
        public IdObject GetObject(string categoryId, int id) {
            return (from g in (from d in _categories where d._groupName == categoryId select d).FirstOrDefault()?._list where g.Id == id select g).FirstOrDefault();
        }
        public IdObject GetObject(string fullId) {
            int.TryParse(fullId[..1], out var categoryId);
            int.TryParse(fullId.Substring(2, 5), out var id);
            var cat = (from d in _categories where d._groupId == categoryId select d).FirstOrDefault()?._list;
            if(cat == null) Debug.Log("Category " + categoryId + " is null!");
            var obj = (from g in cat where g.Id == id select g).FirstOrDefault();
            if(obj == null) Debug.Log("IdObject " + id + " is null!");
            return obj;
        }
    }
}