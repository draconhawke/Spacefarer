using QuestSystem.Utility;
using Spacefarer.QuestSystem;
using Spacefarer.Source;

namespace Spacefarer {
    public class Quest : IIdentity, IClonable<Quest>, IEditable {
        public static event SFEventHandler<Quest> Completed;
        public static event SFEventHandler<Quest> Began;

        private string _name;
        private string _description;
        private QuestType _type;
        private QuestState _status;
        private bool _isOptional;
        private string _actorName;
        private string _itemName;
        private int _quantityNeeded;
        private int _quantityRemaining;

        #region Getters & Setters
        public string Name { get { return _name; } set { _name = value; } }
        public string decription { get { return _description; } set { _description = value; } }
        public QuestType type { get { return _type; } set { _type = value; } }
        public QuestState status { get { return _status; } set { _status = value; } }
        public bool isOptional { get { return _isOptional; } set { _isOptional = value; } }
        public string actorName { get { return _actorName; } set { _actorName = value; } }
        public string itemName { get { return _itemName; } set { _itemName = value; } }
        public int quantityNeeded { get { return _quantityNeeded; } set { _quantityNeeded = value; } }
        public int quantityRemaining { get { return _quantityRemaining; } set { _quantityRemaining = value; } }

        #endregion
        #region Constructors
        public Quest() : this(string.Empty, string.Empty, QuestType.None, string.Empty, string.Empty, 0) { }
        public Quest(string name, string desc, QuestType type, string actorName, string itemName, int quantityNeeded, bool isOptional = false) {
            _name = name;
            _description = desc;
            _type = type;
            _status = QuestState.Inactive;
            _actorName = actorName;
            _itemName = itemName;
            _quantityNeeded = quantityNeeded;
            _quantityRemaining = _quantityNeeded;
            _isOptional = isOptional;
        }
        public Quest Clone(Quest obj) {
            return (Quest)MemberwiseClone();
        }
        #endregion
        private void AddEventListeners() {
            switch (_type) {
                case QuestType.Collection:
                    //Item.Collected += Item_Collected;
                    Source.Item.Collected += Item_Collected;
                    break;
                case QuestType.Delivery:
                    Actor.DeliveredItem += Actor_Delivered;
                    break;
                case QuestType.Elimination:
                    Actor.Eliminated += Actor_Eliminated;
                    break;
                case QuestType.Interaction:
                    Actor.Interacted += Actor_Interacted;
                    break;
            }
        }
        private void RemoveEventListeners()
        {
            switch (_type)
            {
                case QuestType.Collection:
                    Source.Item.Collected -= Item_Collected;
                    break;
                case QuestType.Delivery:
                    Actor.DeliveredItem -= Actor_Delivered;
                    break;
                case QuestType.Elimination:
                    Actor.Eliminated -= Actor_Eliminated;
                    break;
                case QuestType.Interaction:
                    Actor.Interacted -= Actor_Interacted;
                    break;
            }
        }

        private void Item_Collected(Source.Item sender) {
            if (_status == QuestState.Active && sender.Name == _itemName) {
                _quantityRemaining--;
                if (_quantityRemaining <= 0)
                    _status = QuestState.Pending;
            }
        }
        private void Actor_Delivered(Actor sender, Source.Item args) {
            if (_status == QuestState.Active && sender.Name == _actorName && args.Name == _itemName) {
                _quantityRemaining--;
                if (_quantityRemaining <= 0)
                    _status = QuestState.Pending;
            }
        }
        private void Actor_Eliminated(Actor sender) {
            if (_status == QuestState.Active && sender.Name == _actorName) {
                _quantityRemaining--;
                if (_quantityRemaining <= 0)
                    _status = QuestState.Pending;
            }
        }
        private void Actor_Interacted(Actor sender) {
            if (_status == QuestState.Active && sender.Name == _actorName)
                _status = QuestState.Pending;
        }

        public void Complete() {
            if (_status == QuestState.Pending)
                ForceComplete();
        }
        public void ForceComplete() {
            _status = QuestState.Complete;
            RemoveEventListeners();
            if (Completed != null)
                Completed(this);
        }
        public void Begin() {
            if (_status == QuestState.Inactive)
                ForceBegin();
        }
        public void ForceBegin() {
            _status = QuestState.Active;
            AddEventListeners();
            if (Completed != null)
                Began(this);
        }
        public void RevertFromDatabase() { }
        public void OnInspectorGUI() {

        }
        public void OnEditorGUI() {

        }
    }
}
