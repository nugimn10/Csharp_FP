using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Csharp_FP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nomor 1
            // var hello = "hello world".Capitalize();
            // Console.WriteLine(hello);

            //Nomor 2
            // var hello = "hello world again".SnakeCase();
            // Console.WriteLine(hello);

            //Nomor 3
            // var hello = "hello world again".KebabCase();
            // Console.WriteLine(hello);

            // Nomor 4
            // var numbers = new []{1,2,3,4,5,6,6,8,8,6,9};
            // var grades = new[]{87.5, 88.5, 60.5, 90.5, 88.5};

            // var mostNumbers = numbers.Mode();

            // var mostGrades = grades.Mode();
            // Console.WriteLine("most number showed : "+mostNumbers+"\n"+"most grade showed : "+mostGrades);

            //Nomor 5
            var satu = 1.Convert();
            var belasan = 12.Convert();
            var puluhan = 90.Convert();
            Console.WriteLine(puluhan);

            //Nomor 6
            // var tulisanPanjang = "ini adalah tulisan yang sangat panjang".Trim(8);

            // Console.WriteLine(tulisanPanjang);

            //Nomor 7
            // var tulisanPanjang = "ini adalah tulisan yang sangat panjang".TrimWords(3);

            // Console.WriteLine(tulisanPanjang);
        }


    }

    
    public static class IEnumerableExtension
    {        
        public static string Capitalize(this string input)
		{           
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            
            var result = string.Join(" ", input.Split(' ')
                                      .Select(word => textInfo.ToTitleCase(word))
                                      .ToArray());
			
            return result.ToString();
		}

        public static string SnakeCase(this string input)
		{           
         
            var result = input.Replace(" ","_");
            return result.ToString();
		}


        public static string KebabCase(this string input){ var result = input.Replace(" ","-"); return result.ToString();}

        public static T Mode<T>(this IEnumerable <T> values)
        {
            return (values.GroupBy(N => N)
                    .OrderByDescending(N => N.Count())
                    .Select(N=>N.Key)).First();
        }

        public static string Convert(this int number)
        {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + Convert(Math.Abs(number));

        string words = "";

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas", "duabelas", "tigabelas", "empat belas", "lima belas", "enam belas", "tujuh belas", "delapan belas", "sembilan belas" };
                var tensMap = new[] { "nol", "sepuluh", "dua puluh", "tiga puluh", "empat puluh", "lima puluh", "enam puluh", "tujuh puluh", "delapan puluh", "sembilan puluh" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words;
        }


        public static string Trim(this string input, int i) 
        {
           var result = input.Substring(0, i) + "...";
           return result;
        } 
       
        public static string TrimWords(this string input, int i) 
        {
            var result =
                string.Join(" ", input.Split(' ').ToList().GetRange(0, i));
            return result;
        } 
 
    }

}
