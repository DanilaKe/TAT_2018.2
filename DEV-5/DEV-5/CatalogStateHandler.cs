namespace DEV_5
{
    public delegate void CatalogStateHandler(object sender, CatalogEventArgs e);

    public class CatalogEventArgs
    {
        public string Message { get; private set;}
        public double Sum { get; private set;}
        public int Count { get; private set;}

        public CatalogEventArgs(string _mes, double _sum, int _count)
        {
            Message = _mes;
            Sum = _sum;
        }
    }
}