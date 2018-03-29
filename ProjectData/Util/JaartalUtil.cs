namespace ProjectData.Util
{
    public class JaartalUtil
    {
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
