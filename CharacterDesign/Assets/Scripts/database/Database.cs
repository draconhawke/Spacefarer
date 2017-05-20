using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace database
{
    [XmlRoot("Database")]
    public class Database<T> where T : IIdentity
    {
        private List<T> _elements;
        [XmlArray("Elements"), XmlArrayItem("Element")]
        public List<T> elements { get { return _elements; } set { _elements = value; } }
        public Database()
        {
            _elements = new List<T>();
        }
        public void Add(T element)
        {
            if (!Contains(element))
            {
                element.id = DetermineID();
                _elements.Add(element);
            }
        }
        public void Clear()
        {
            _elements.Clear();
        }
        public int IndexOf(T element)
        {
            return FindElement(element.id);
        }
        public int Length
        {
            get { return _elements.Count; }
        }
        public int IndexOf(int id)
        {
            return FindElement(id);
        }
        public int IndexOf(string name)
        {
            return FindElement(name);
        }
        public T Get(int id)
        {
            int i = FindElement(id);
            if (i >= 0)
                return _elements[i];
            return default(T);
        }
        public T Get(string name)
        {
            int i = FindElement(name);
            if (i >= 0)
                return _elements[i];
            return default(T);
        }
        public T GetAt(int index)
        {
            if (index >= 0 && index < _elements.Count)
                return _elements[index];
            return default(T);
        }
        public void Remove(T element)
        {
            _elements.Remove(element);
        }
        public void Remove(int id)
        {
            int i = FindElement(id);
            if (i >= 0)
                _elements.RemoveAt(i);
        }
        public void Remove(string name)
        {
            int i = FindElement(name);
            if (i >= 0)
                _elements.RemoveAt(i);
        }
        public void RemoveAt(int index)
        {
            _elements.RemoveAt(index);
        }
        public void Replace(int index, T element)
        {
            if (index >= 0 && index < _elements.Count)
                _elements[index] = element;
            Add(element);
        }
        private int DetermineID()
        {
            int id = 0;
            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].id > id)
                    id = _elements[i].id;
            }
            return id + 1;
        }
        private bool Contains(T element)
        {
            return FindElement(element.id) >= 0;
        }
        private int FindElement(int id)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].id == id)
                    return i;
            }
            return -1;
        }
        private int FindElement(string name)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                if (elements[i].name == name) return i;
            }
            return -1;
        }
        public void Save<U>(string path) where U : Database<T>
        {
            var serializer = new XmlSerializer(typeof(U));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }
        public static U Load<U>(string path) where U : Database<T>, new()
        {
            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(U));
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    return serializer.Deserialize(stream) as U;
                }
            }
            return new U();
        }
    }
}