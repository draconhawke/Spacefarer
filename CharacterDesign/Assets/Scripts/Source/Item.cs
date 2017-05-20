using UnityEngine;
using QuestSystem.Utility;
using Spacefarer.QuestSystem;

namespace Spacefarer.Source {
    public class Item : IIdentity, IClonable<Item>, IEditable {
        public static event SFEventHandler<Item> Collected;

        private string _name;
        private string _description;
        private Sprite _icon;
        private int _value;

        #region Getters & Setters
        public string Name { get { return _name; } set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public Sprite Icon { get { return _icon; } set { _icon = value; } }
        public int Value { get { return _value; } set { _value = value; } }
        #endregion
        #region Constructors
        public Item() {
            _name = string.Empty;
            _description = string.Empty;
            _icon = null;
            _value = 0;
        }
        public Item Clone(Item obj) {
            return (Item)MemberwiseClone();
        }
        #endregion
        public static void CollectItem(Item item) {
            if (Collected != null)
                Collected(item);
        }
        public void RevertFromDatabase() {

        }
        public void OnInspectorGUI()  {

        }
        public void OnEditorGUI() {

        }
    }
}