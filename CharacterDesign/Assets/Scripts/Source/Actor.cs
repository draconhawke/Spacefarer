using QuestSystem.Utility;
using Spacefarer.QuestSystem;
using UnityEngine;
using UnityEditor;

namespace Spacefarer.Source {
    public class Actor : IIdentity, IClonable<Actor>, IEditable {
        public static SFEventHandler<Actor, Item> DeliveredItem;
        public static SFEventHandler<Actor> Eliminated;
        public static SFEventHandler<Actor> Interacted;

        private string _name;
        private string _nickName;

        #region Getters & Setters
        public string Name { get { return _name; } set { _name = value; } }
        public string NickName { get { return _nickName; } set { _nickName = value; } }
        #endregion
        #region Constructors
        public Actor() {
            _name = "New name";
            _nickName = "";
        }
        #endregion
        public Actor Clone(Actor obj) {
            return (Actor)MemberwiseClone();
        }
        public void OnInspectorGUI() {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Open", EditorStyles.miniButtonLeft)) {

            }
            if (GUILayout.Button("Revert", EditorStyles.miniButtonMid))  {

            }
            if (GUILayout.Button("Apply", EditorStyles.miniButtonRight))  {

            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.LabelField("Name: ", _name);
            EditorGUILayout.TextField("Nickname: ", _nickName);
            if (GUILayout.Button("Sync with Database"))  {
                //Use name to reload info from database
            }
        }
        public void OnEditorGUI() {
            EditorGUILayout.TextField("Name: ", _name);
            EditorGUILayout.TextField("Nickname: ", _nickName);
        }
        public void RevertFromDatabase() { }
    }
}