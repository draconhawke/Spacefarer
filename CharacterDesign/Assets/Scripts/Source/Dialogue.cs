using System;
using QuestSystem.Utility;
using Spacefarer.QuestSystem;
using UnityEngine;

namespace Spacefarer.Source {
    public class Dialogue : IIdentity, IClonable<Dialogue>, IEditable {
        public static SFEventHandler<Actor> Interacted;

        private string _name;

        #region Getters & Setters
        public string Name { get { return _name; } set { _name = value; } }
        #endregion
        #region Constructors
        public Dialogue() {
            _name = "New Dialogue";
        }
        #endregion
        public Dialogue Clone(Dialogue obj)
        {
            return (Dialogue)MemberwiseClone();
        }
        public void RevertFromDatabase() { }
        public void OnInspectorGUI() {

        }
        public void OnEditorGUI() {

        }
    }
}