using Spacefarer.Source;
using UnityEditor;
using UnityEngine;

namespace Spacefarer {
    [CustomEditor(typeof(ActorContainer))]
    public class ActorEditor : Editor {
        private Actor _target;
        public override void OnInspectorGUI() {
            _target = ((ActorContainer)target).actor;
            if (_target != null)
                _target.OnInspectorGUI();
            else
                if (GUILayout.Button("New Actor"))
                    _target = new Actor();
        }
    }
}
