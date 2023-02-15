//using UnityEditor;
using UnityEngine;

namespace Pixygon.ID {
    public class IdObject : ScriptableObject {
        [SerializeField] private int _categoryId;
        [SerializeField] private int _id;


        private bool _idSet;
        private int _actualId;
        
        public IdType _idType;

        #if UNITY_EDITOR
        [ContextMenu("Update ID")]
        private void UpdateId() {
            var i = GetFullID;
            UnityEditor.EditorUtility.SetDirty(this);
        }
        #endif
        
        public int GetFullID {
            get
            {
                if (_idSet) return _actualId;
                int.TryParse($"{_categoryId}{_id:D4}", out _actualId);
                _idSet = true;
                return _actualId;
            }
        }

        public string GetFullIDString => $"{_categoryId:D2}{_id:D4}";

        public int CategoryId => _categoryId;
        public int Id => _id;

        public bool IsZero => _id == 0;

        public void SetIDObject(int categoryID, int id) {
            _categoryId = categoryID;
            _id = id;
        }
    }
}