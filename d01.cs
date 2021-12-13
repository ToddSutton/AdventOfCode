namespace AdventOfCode {
    public partial class Day01 {
        public static void D01(string file) {
            String[] lines = System.IO.File.ReadAllLines(file);
            int comparison = int.Parse(lines[0]);
            int count = 0;
            foreach (string depth in lines) {
                if (int.Parse(depth) > comparison) {
                    count++;
                }
                comparison=int.Parse(depth);
            }
            Console.WriteLine(count);
            count = 0;
            comparison = int.Parse(lines[0]) + int.Parse(lines[1]) + int.Parse(lines[2]);
            int temp;
            for (int i = 3; i<lines.Length; i+=1) { 
                temp = int.Parse(lines[i-2]) + int.Parse(lines[i-1]) + int.Parse(lines[i]);
                if (temp > comparison) {
                    count++;
                }
                comparison = temp;
            }
            Console.WriteLine(count);
        }
    }
}