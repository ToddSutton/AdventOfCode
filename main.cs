// See https://aka.ms/new-console-template for more information
namespace AdventOfCode {
    public partial class AdventOfCode {
        public static void Main() {
            current = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //Day01.D01("D:/Desktop/AdventOfCode/d01");
            //Day02.D02("D:/Desktop/AdventOfCode/d02");
            Day03.D03(current + "d03");
            //Day09.D09("D:/Desktop/AdventOfCode/d09");
        }
    }
}