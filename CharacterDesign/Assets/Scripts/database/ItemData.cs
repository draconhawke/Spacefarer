using UnityEditor;

namespace database
{
    public struct ItemData : IIdentity
    {
        private int _id;
        private string _name;
        private string _description;
        private int _price;

        public int id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string description { get { return _description; } set { _description = value; } }
        public int price { get { return _price; } set { _price = value; } }


        public ItemData(string name, string description, int price)
        {
            _id = -1;
            _name = name;
            _description = description;
            _price = price;
        }
        public void ShowEditable()
        {
            //EditorGUILayout.LabelField("ID:", _id.ToString());
            //_name = EditorGUILayout.TextField("Name:", _name);
            //_description = EditorGUILayout.TextField("Description:", _description);
            //_price = EditorGUILayout.IntField("Price:", _price);
        }
    }
}
