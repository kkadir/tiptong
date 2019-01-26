namespace Tiptong.Framework.Domain
{
    using System;
    using System.Linq;
    using System.Reflection;
    
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var publicProperties = GetType().GetTypeInfo().GetProperties();

            if (publicProperties?.Length > 0)
            {
                return publicProperties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);

                    return Equals(left, right);
                });
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is ValueObject<T> item)
            {
                return Equals((T)item);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;

            PropertyInfo[] publicProperties = GetType().GetTypeInfo().GetProperties();

            if (publicProperties?.Length > 0)
            {
                foreach (var property in publicProperties)
                {
                    object value = property.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = (hashCode * ((changeMultiplier) ? 59 : 114)) + value.GetHashCode();

                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        hashCode ^= 13;
                    }
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (Equals(left, null) || Equals(right, null))
            {
                return false;
            }

             return left.Equals(right);            
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}