using System;

namespace GenericListVersion
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major
        {
            get { return this.major; }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be 1 or greater");
                }

                this.major = value;
            }
        }

        public int Minor
        {
            get { return this.minor; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be 0 or greater");
                }

                this.minor = value;
            }
        }
    }
}
