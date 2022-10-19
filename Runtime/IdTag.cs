using System;

namespace Pixygon
{
    [Serializable]
    public class IdTag
    {
        public int _categoryId;
        public int _id;
        public IdType _idType;
    }

    public enum IdType
    {
        Actor = 0,
        Quest = 1,
        Item = 2,
        Avatar = 3,
        Effect = 4,
        Profession = 5,
        Conversation = 6,
        Application = 7
    }
}