namespace Trekish.Models
{
    public interface IEquipmentClass
    {
        /// <summary>
        /// 1.0 is perfect efficiency which means there are no 
        /// </summary>
        double Efficiency { get; }
        int TechLevel { get; }
        string Name { get; }
    }

    public interface IStorageSystem
    {
        double MaxCapacity { get; }
        double Balance { get; }

        /// <summary>
        /// checks max capacity before increasing value of balance
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if MaxCapacity > balance + value </returns>
        bool Deposit(double value);

        /// <summary>
        /// checks balance before reducing value of balance
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if balance - value > 0</returns>
        bool Withdraw(double value);
    }

    public class StorageSystem : IStorageSystem
    {
        public StorageSystem(double maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }

        public double MaxCapacity { get; }
        public double Balance { get; private set; }

        public bool Deposit(double value)
        {
            if(Balance + value <= MaxCapacity)
            {
                Balance += value;
                return true;
            }
            return false;
        }

        public bool Withdraw(double value)
        {
            if (Balance - value >= 0)
            {
                Balance -= value;
                return true;
            }
            return false;
        }
    }
}
