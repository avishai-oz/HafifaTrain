namespace Train
{
    public interface IWalletService
    {
        void DeductMoney(IUser user, int amount);
        void LoadMoney(IUser user, int amount);
    }
}