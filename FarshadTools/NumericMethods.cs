using System;

namespace FarshadTools
{
    public static class NumericMethods
    {
      

        internal static string PartsName(int part)
        {
            switch (part)
            {
                case 1:
                    return "هزار";

                case 2:
                    return "میلیون";

                case 3:
                    return "میلیارد";

                default:
                    return "";
            }
        }

    }
}
