namespace Application.Features.Posts.Handlers;

public static class PostTagHelpers
{
    public static List<string> GetTags(string content)
    {
        var split = content.ToLower().Split(" ");
        var query = from word in split
            where word[0].ToString() == "#"
            select word.Substring(1, word.Length - 1);

        return new HashSet<string>(query).ToList();
    }
    
    public static (List<string>, List<string>) GetTagDifferences(List<string> previous, List<string> current)
    {
        var oldMap = new HashSet<string>(previous);
        var newMap = new HashSet<string>(current);

        var deleted = previous.Where(tag => !newMap.Contains(tag)).ToList();
        var added = current.Where(tag => !oldMap.Contains(tag)).ToList();
        
        return (added, deleted);
    }
}