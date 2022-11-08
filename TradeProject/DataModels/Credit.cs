namespace TradeProject.DataModels
{
    public class Credit
    {

        private string name;

        public Credit(string name)
        {
            this.name = name;
        }

        public string GetName() { return name; }
    }
}
