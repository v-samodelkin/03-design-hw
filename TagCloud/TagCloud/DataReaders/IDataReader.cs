namespace TagCloud
{
    interface IDataReader
    {
        string RawData();
        IData ClearData();
    }
}
