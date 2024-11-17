namespace CollectionBuilder.Common;

public interface IDeck
{
    List<string> Errors { get; }
    bool IsValid();
    void AddCard(string card);
    List<string> GetContents();
    string GetFormattedList();
}
