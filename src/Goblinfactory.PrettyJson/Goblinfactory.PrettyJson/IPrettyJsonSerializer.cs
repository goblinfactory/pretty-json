namespace Goblinfactory.PrettyJson
{
    public interface IPrettyJsonSerializer
    {
        string Serialize<T>(T src) where T : class;
        object DeSerialize(string src);
    }
}
