namespace database
{
    public interface IIdentity : IEditable
    {
        string name { get; set; }
        int id { get; set; }
    }
}
