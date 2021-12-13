namespace AdventOfCode {
    public partial class Day03 {
        public static void D03(string file) {
            String[] lines = System.IO.File.ReadAllLines(file);
            int[] ones = new int[lines[0].Length];
            int[] zeros = new int[lines[0].Length];
            for (int i = 0; i < lines[0].Length; i++) {
                ones[i] = 0;
                zeros[i] = 0;
            }
            foreach (String line in lines) {
                for (int i = 0; i < lines[0].Length; i++) {
                    if((int) char.GetNumericValue(line[i]) == 1) {
                        ones[i]++;
                    } else {
                        zeros[i]++;
                    }
                }
            }
            int gamma = 0;
            int epsilon = 0;
            for (int i = 0; i < ones.Length; i++) {
                if (ones[i] > zeros[i]) {
                    gamma += (int)Math.Pow(2,ones.Length - 1 - i);
                } else {
                    epsilon += (int) Math.Pow(2,ones.Length - 1 - i);
                }
            }
            Console.WriteLine(epsilon*gamma);

            String[] oxygenS = Dwindle(ones,zeros,lines,1,0);
            String[] c02S = Dwindle(ones,zeros,lines,0,0);
            int oxygen = 0;
            int c02 = 0;
            for (int i = 0;i < oxygenS[0].Length;i++) {
                if ((int) char.GetNumericValue(oxygenS[0][i]) == 1) {
                    oxygen += (int) Math.Pow(2,oxygenS[0].Length - 1 - i);
                }
                if ((int) char.GetNumericValue(c02S[0][i]) == 1) {
                    c02 += (int) Math.Pow(2,oxygenS[0].Length - 1 - i);
                }
            }
            Console.WriteLine(oxygen*c02);
        }

        static String[] Dwindle(int[] ones, int[] zeros, String[] list, int primary, int position) {
            if (list.Length > 1) {
                ones[position] = 0;
                zeros[position] = 0;
                foreach (String line in list) {
                    if ((int) char.GetNumericValue(line[position]) == 1) {
                        ones[position]++;
                    } else {
                        zeros[position]++;
                    }
                }
                int count = 0;
                if (primary == 0) {
                    if (ones[position] < zeros[position]) {
                        String[] filtered = new String[ones[position]];
                        foreach (String line in list) {
                            if ((int) char.GetNumericValue(line[position]) != primary) {
                                filtered[count++] = line;
                            }
                        }
                        return Dwindle(ones,zeros,filtered,primary,position+1);
                    } else {
                        String[] filtered = new String[zeros[position]];
                        foreach (String line in list) {
                            if ((int) char.GetNumericValue(line[position]) == primary) {
                                filtered[count++] = line;
                            }
                        }
                        return Dwindle(ones,zeros,filtered,primary,position+1);
                    }
                } else {
                    if (ones[position] < zeros[position]) {
                        String[] filtered = new String[zeros[position]];
                        foreach (String line in list) {
                            if ((int) char.GetNumericValue(line[position]) != primary) {
                                filtered[count++] = line;
                            }
                        }
                        return Dwindle(ones,zeros,filtered,primary,position+1);
                    } else {
                        String[] filtered = new String[ones[position]];
                        foreach (String line in list) {
                            if ((int) char.GetNumericValue(line[position]) == primary) {
                                filtered[count++] = line;
                            }
                        }
                        return Dwindle(ones,zeros,filtered,primary,position+1);
                    }
                }
            }
            return list;
        }
    }
}