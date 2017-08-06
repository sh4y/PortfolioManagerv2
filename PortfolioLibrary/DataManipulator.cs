namespace PortfolioLibrary
{
    public class DataManipulator
    {
        private static T[] Slice<T>(T[] source, int start, int end)
        {
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }

        public string[] GetRawData(string content)
        {
            string[] data = content.Split('\n');
            return Slice(data, 7, data.Length-1);
        }
    }
}
