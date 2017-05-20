namespace Spacefarer.Source {
    public interface IEditable     {
        void OnInspectorGUI();
        void OnEditorGUI();
        void RevertFromDatabase();
    }
}
