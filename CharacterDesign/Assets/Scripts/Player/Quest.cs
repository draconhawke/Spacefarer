using Spacefarer.QuestSystem;

[System.Serializable]
public class Quest {
    public string QuestName;
    public int QuestID;
    private string v1;
    private string v2;
    private QuestType collection;
    private string empty;
    private string itemName;
    private int v3;

    public Quest(string v1, string v2, QuestType collection, string empty, string itemName, int v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.collection = collection;
        this.empty = empty;
        this.itemName = itemName;
        this.v3 = v3;
    }
}
