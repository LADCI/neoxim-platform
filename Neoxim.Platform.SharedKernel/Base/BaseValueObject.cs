namespace Neoxim.Platform.SharedKernel
{
    /// <summary>
    /// Value Object
    /// </summary>
    public class BaseValueObject : IComparable
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is BaseValueObject x)
            {
                return CompareTo(x);
            }

            throw new ArgumentException("", nameof(obj));
        }

        public override bool Equals(object obj)
        {
            return (obj is BaseValueObject other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 1;
        }

        public static bool operator ==(BaseValueObject left, BaseValueObject right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(BaseValueObject left, BaseValueObject right)
        {
            return !(left == right);
        }

        public static bool operator <(BaseValueObject left, BaseValueObject right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(BaseValueObject left, BaseValueObject right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(BaseValueObject left, BaseValueObject right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(BaseValueObject left, BaseValueObject right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}