using UnityEditor;

namespace database
{
    public struct ActorData : IIdentity
    {
        private int _id;
        private string _name;
        private string _description;
        private float _curHP;
        private float _maxHP;

        public int id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string description { get { return _description; } set { _description = value; } }
        public float curHP { get { return _curHP; } set { _curHP = value; } }
        public float maxHP { get { return _maxHP; } set { _maxHP = value; } }

        public ActorData(string name, string description, float maxHealth)
        {
            _id = -1;
            _name = name;
            _description = description;
            _curHP = _maxHP = maxHealth;
        }
        public void ShowEditable()
        {
            //EditorGUILayout.LabelField("ID:", _id.ToString());
            //_name = EditorGUILayout.TextField("Name:", _name);
            //_description = EditorGUILayout.TextField("Description:", _description);
            //_curHP = EditorGUILayout.FloatField("Current HP:", _curHP);
            //_maxHP = EditorGUILayout.FloatField("Max HP:", _maxHP);
        }
    }
}