namespace Train
{
    public interface IWalletService
    {
        void DeductMoney(IUser user, int amount, IDBManager db);
        void LoadMoney(IUser user, int amount, IDBManager db);
    }
}