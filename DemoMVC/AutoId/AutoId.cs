namespace DemoMVC.AutoId
{
    public class AutoId 
    {
        // private string id = "STD009";

        public  static string GetNextId(string id)
        {
         
            string numberPart = id.Substring(3);
            int number = int.Parse(numberPart);

            number++; 

            id = "STD" + number.ToString("D3");

            return id;
        }
    }
}
