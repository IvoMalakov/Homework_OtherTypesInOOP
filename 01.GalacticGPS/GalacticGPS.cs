using System;

namespace GPS
{
    public class GalacticGPS
    {
        public static void Main()
        {
            try
            {
                Location home = new Location(18.037986, 28.870097, Planet.Earth);

                Console.WriteLine(home);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("Thnak you to use my program. Have a nice day");
            }
        }
    }
}