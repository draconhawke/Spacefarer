namespace Spacefarer.QuestSystem {
    public interface IClonable<T> {
        T Clone(T obj);
    }
}
