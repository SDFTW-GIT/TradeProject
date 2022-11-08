namespace TradeProject.DataModels
{
    public class Inventory
    {
        private Item[] inventory;

        public Inventory(Item[] inventory)
        {
            this.inventory = inventory;
        }

        public Item[] GetInventory() { return inventory; }

    }
}
