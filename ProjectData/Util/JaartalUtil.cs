namespace ProjectData.Util
{
    public class JaartalUtil
    {
        /// <summary>
        /// Get a jaartal code from the given number.
        /// </summary>
        /// <param name="jaartal">A number of a year.</param>
        /// <returns>It gives you a year code of the given jaartal.</returns>
        public static string GetJaartalCode(int jaartal)
        {
            switch (jaartal)
            {
                case 2010:
                    return "2010JJ00";
                case 2011:
                    return "2011JJ00";
                case 2012:
                    return "2012JJ00";
                case 2013:
                    return "2013JJ00";
                case 2014:
                    return "2014JJ00";
                case 2015:
                    return "2015JJ00";
                case 2016:
                    return "2016JJ00";
                case 2017:
                    return "2017JJ00";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Parse the given string to a number and a jaartal code from the given number.
        /// </summary>
        /// <param name="jaartal">A string of a year.</param>
        /// <returns>It gives you a year code of the given jaartal.</returns>
        public static string GetJaartalCode(string jaartal)
        {
            if (string.IsNullOrEmpty(jaartal))
            {
                return string.Empty;
            }
            return GetJaartalCode(int.Parse(jaartal));
        }

    }
}
