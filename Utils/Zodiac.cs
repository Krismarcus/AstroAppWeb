
using Astrodaiva.Data.Enums;

namespace Astrodaiva.Blazor.Utils
{
    public static class Zodiac
    {
        private static readonly string[] Symbols = { "♈","♉","♊","♋","♌","♍","♎","♏","♐","♑","♒","♓" };
        private static readonly string[] Names = { "Aries","Taurus","Gemini","Cancer","Leo","Virgo","Libra","Scorpio","Sagittarius","Capricorn","Aquarius","Pisces" };

        public static string Symbol(int signIndex)
        {
            int i = ((signIndex % 12) + 12) % 12;
            return Symbols[i];
        }

        public static string Name(int signIndex)
        {
            int i = ((signIndex % 12) + 12) % 12;
            return Names[i];
        }

        public static string ImageFile(ZodiacSign sign) => sign switch
        {
            ZodiacSign.Aries => "aries_blue.png",
            ZodiacSign.Taurus => "taurus_blue.png",
            ZodiacSign.Gemini => "gemini_blue.png",
            ZodiacSign.Cancer => "cancer_blue.png",
            ZodiacSign.Leo => "leo_blue.png",
            ZodiacSign.Virgo => "virgo_blue.png",
            ZodiacSign.Libra => "libra_blue.png",
            ZodiacSign.Scorpio => "scorpio_blue.png",
            ZodiacSign.Sagittarius => "sagittarius_blue.png",
            ZodiacSign.Capricorn => "capricorn_blue.png",
            ZodiacSign.Aquarius => "aquarius_blue.png",
            ZodiacSign.Pisces => "pisces_blue.png",
            _ => "unknown.png"
        };

        public static string ImagePath(ZodiacSign sign) => $"img/zodiac/{ImageFile(sign)}";

        public static string Color(ZodiacSign sign) => sign switch
        {
            ZodiacSign.Aries => "#FFB347",
            ZodiacSign.Taurus => "#77DD77",
            ZodiacSign.Gemini => "#AEC6CF",
            ZodiacSign.Cancer => "#CFCFC4",
            ZodiacSign.Leo => "#FFD700",
            ZodiacSign.Virgo => "#B2BEB5",
            ZodiacSign.Libra => "#FFB7B2",
            ZodiacSign.Scorpio => "#C23B22",
            ZodiacSign.Sagittarius => "#F49AC2",
            ZodiacSign.Capricorn => "#A9A9A9",
            ZodiacSign.Aquarius => "#779ECB",
            ZodiacSign.Pisces => "#B39EB5",
            _ => "#CCCCCC"
        };
    }
}
