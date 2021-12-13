namespace AdventOfCode {
    public partial class Day02 {
        public static void D02(string file) {
            String[] lines = System.IO.File.ReadAllLines(file);
            int forward = 0;
            int depth = 0;
            string[] direction;
            foreach (String movement in lines) {
                direction = movement.Split(' ');
                if (direction[0] == "forward") {
                    forward += int.Parse(direction[1]);
                }else if(direction[0] == "down") {
                    depth += int.Parse(direction[1]);
                } else {
                    depth -= int.Parse(direction[1]);
                }
            }
            Console.WriteLine(forward*depth);

            forward = 0;
            depth = 0;
            int aim = 0;
            foreach (String movement in lines) {
                direction = movement.Split(' ');
                if (direction[0] == "forward") {
                    forward += int.Parse(direction[1]);
                    depth += aim * int.Parse(direction[1]);
                } else if (direction[0] == "down") {
                    aim += int.Parse(direction[1]);
                } else {
                    aim -= int.Parse(direction[1]);
                }
            }
            Console.WriteLine(forward*depth);
        }
    }
}