namespace TradeProject.DataModels
{
    public class Profile
    {
        private User user;
        private Inventory inventory;
        private Credit credit;

        public Profile(User user, Inventory inventory, Credit credit)
        {
            this.user = user;
            this.inventory = inventory;
            this.credit = credit;
        }

        public User GetUser() { return user; }
        public Inventory GetInventory() { return inventory; }
        public Credit GetCredit() { return credit; }

    }
}
