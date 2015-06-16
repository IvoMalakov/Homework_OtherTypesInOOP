using System;

namespace GPS
{
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planetum = planet;
        }

        public double Latitude
        {
            get { return this.latitude; }

            set
            {
                if (value < -180.0 || value > 180.0)
                {
                    throw new ArgumentOutOfRangeException("value", "Error! Your latitude cordinates must be between" +
                                                                   " -180.00 and 180.00 ");
                }

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }

            set
            {
                if (value < -90.0 || value > 90.0)
                {
                    throw new ArgumentOutOfRangeException("value", "Error! Your longitude cordinates must be between" +
                                                                   " -90.00 and 90.00 ");
                }

                this.longitude = value;
            }
        }

        public Planet Planetum { get; set; }

        public override string ToString()
        {
            return String.Format("<{0}>, <{1}> - <{2}>", this.Latitude, this.Longitude, this.Planetum);
        }
    }
}
