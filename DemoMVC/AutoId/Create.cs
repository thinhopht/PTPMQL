namespace DemoMVC.AutoId
{
    public class Create ()
    {
        // vd: id = "PS001"
        // tách phần số từ id
        public static string GetNextId(string id)
        {
            string number = id.Substring(2); // "001"
            int a = int.Parse(number);
            a++;
            id = "PS" + a.ToString("D3");
            return id;
        }
    }
}