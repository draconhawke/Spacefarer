using System;
using UnityEditor;
using UnityEngine;

namespace database
{
    public class DatabaseEditor : EditorWindow
    {
        private const float WINDOW_MIN_WIDTH = 800.0f;
        private const float WINDOW_MIN_HEIGHT = 600.0f;

        private enum Tab { Actors, Items, Weapons, Armors }
        private Tab _tab;
        private Vector2 _selectionScrollPos;
        private Vector2 _editScrollView;
        private bool _editMode;
        private int _selectedIndex;
        private IIdentity _data;

        [MenuItem("Window/Data Editor")]
        public static void GetWindow()
        {
            DatabaseEditor window = GetWindow<DatabaseEditor>("DataEditor", true);
            window.minSize = new Vector2(WINDOW_MIN_WIDTH, WINDOW_MIN_HEIGHT);
        }
        private void OnEnable()
        {
            _tab = Tab.Actors;
            GameData.Load();
        }
        private void OnGUI()
        {
            ShowTabs();
            ShowContent();
        }
        private void Reset()
        {
            _selectionScrollPos = Vector2.zero;
            _editScrollView = Vector2.zero;
            _editMode = false;
            _selectedIndex = -1;
            GUI.FocusControl(null);
        }
        private void ShowTabs()
        {
            if (_editMode)
                GUILayout.Toolbar((int)_tab, Enum.GetNames(typeof(Tab)));
            else
                _tab = (Tab)GUILayout.Toolbar((int)_tab, Enum.GetNames(typeof(Tab)));
        }
        private void ShowContent()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            switch (_tab)
            {
                case Tab.Actors:
                    ShowSelection<Database<ActorData>, ActorData>(GameData.actors);
                    ShowEditView<Database<ActorData>, ActorData>(GameData.actors);
                    break;
                case Tab.Items:
                    ShowSelection<Database<ItemData>, ItemData>(GameData.items);
                    ShowEditView<Database<ItemData>, ItemData>(GameData.items);
                    break;
                case Tab.Weapons:
                    ShowSelection<Database<WeaponData>, WeaponData>(GameData.weapons);
                    ShowEditView<Database<WeaponData>, WeaponData>(GameData.weapons);
                    break;
                case Tab.Armors:
                    ShowSelection<Database<ArmorData>, ArmorData>(GameData.armor);
                    ShowEditView<Database<ArmorData>, ArmorData>(GameData.armor);
                    break;
            }
            EditorGUILayout.EndHorizontal();
        }
        private void ShowSelection<T, U>(T database) where T : Database<U> where U : IIdentity, new()
        {
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.Width(WINDOW_MIN_WIDTH / 3));
            _selectionScrollPos = EditorGUILayout.BeginScrollView(_selectionScrollPos);
            for (int i = 0; i < database.Length; i++)
            {
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.Height(20f));
                GUILayout.Label(string.Format("[{ 0}] { 1}", database.GetAt(i).id, database.GetAt(i).name));
                if (!_editMode)
                {
                    if (GUILayout.Button("Edit", GUILayout.Width(40f)))
                    {
                        _editMode = true;
                        _selectedIndex = i;
                        _data = database.GetAt(i);
                    }
                    if (GUILayout.Button("Delete", GUILayout.Width(50f)))
                    {
                        database.RemoveAt(i);
                        SaveChanges();
                        break;
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
            if (GUILayout.Button("Add New", GUILayout.ExpandWidth(true)))
            {
                _selectedIndex = -1;
                _editMode = true;
                _data = new U();
            }
            EditorGUILayout.EndVertical();
        }
        private void ShowEditView<T, U>(T database) where T : Database<U> where U : IIdentity
        {
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            if (_editMode)
            {
                _editScrollView = EditorGUILayout.BeginScrollView(_editScrollView, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
                _data.ShowEditable();
                EditorGUILayout.EndScrollView();
                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                if (GUILayout.Button("Save"))
                {
                    if (_selectedIndex == -1)
                        database.Add((U)_data);
                    else
                        database.Replace(_selectedIndex, (U)_data);
                    SaveChanges();
                }
                if (GUILayout.Button("Cancel"))
                    Reset();                
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
        private void SaveChanges() {
            GameData.Save();
            Reset();
        }
    }
}
