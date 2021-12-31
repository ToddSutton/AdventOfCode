namespace AdventOfCode {
	public partial class Day08 {
		public static void D08(string file) {
			String[] lines = File.ReadAllLines(file);
			int part1 = 0;
			int part2 = 0;

			for (int i = 0; i < lines.Length; i++) {
				String[] temp = lines[i].Split(" | ");
				String[] input = temp[0].Split(" ");
				int zero = -1;
				int one = -1;
				int two = -1;
				int three = -1;
				int four = -1;
				int five = -1;
				int six = -1;
				int seven = -1;
				int eight = -1;
				int nine = -1;
				for (int j = 0; j < 10; j++) {
					switch (input[j].Length) {
						case 2:
							one = j;
							break;
						case 4:
							four = j;
							break;
						case 3:
							seven = j;
							break;
						case 7:
							eight = j;
							break;
					}
				}
				for (int j = 0; j < 10; j++) {
					int found = 0;
					switch (input[j].Length) {
						case 6:
							if (six == -1) {
								for (int k = 0; k < 2; k++) {
									for (int l = 0; l < 6; l++) {
										if (input[one][k] == input[j][l]) {
											found++;
										}
									}
								}
								if (found == 1) { six = j; } else { found = 0; }
							}
							if (nine == -1 && found == 0) {
								for (int k = 0; k < 4; k++) {
									for (int l = 0; l < 6; l++) {
										if (input[four][k] == input[j][l]) {
											found++;
										}
									}
								}
								if (found == 4) { nine = j; } else { found = 0; }
							}
							if (zero == -1 && found == 0) { zero = j; }
							break;
						case 5:
							if (three == -1) {
								for (int k = 0; k < 2; k++) {
									for (int l = 0; l < 5; l++) {
										if (input[one][k] == input[j][l]) {
											found++;
										}
									}
								}
								if (found == 2) { three = j; } else { found = 0; }
							}
							if (five == -1 && found == 0) {
								for (int k = 0; k < 4; k++) {
									for (int l = 0; l < 5; l++) {
										if (input[four][k] == input[j][l]) {
											found++;
										}
									}
								}
								if (found == 3) { five = j; } else { found = 0; }
							}
							if (two == -1 && found == 0) { two = j; }
							break;
					}
				}
				String[] output = temp[1].Split(" ");
				for (int j = 0; j<output.Length; j++) {
					bool discovered = true;
					switch (output[j].Length) {
						// one
						case 2:
							part1++;
							part2 += (int)Math.Pow(10,output.Length-1-j);
							break;
						// four
						case 4:
							part1++;
							part2 += 4*(int) Math.Pow(10,output.Length-1-j);
							break;
						// seven
						case 3:
							part1++;
							part2 += 7*(int) Math.Pow(10,output.Length-1-j);
							break;
						// eight
						case 7:
							part1++;
							part2 += 8*(int) Math.Pow(10,output.Length-1-j);
							break;
						// zero, six, nine
						case 6:
							//zero
							for (int k = 0; k < 6; k++) {
								if (!input[zero].Contains(output[j][k])) {
									discovered = false;
								}
							}
							if (discovered) {
								break;
							} else { discovered = true; }
							//six
							for (int k = 0; k < 6; k++) {
								if (!input[six].Contains(output[j][k])) {
									discovered = false;
								}
							}
							if (discovered) {
								part2 += 6*(int) Math.Pow(10,output.Length-1-j);
								break;
							} else { discovered = true; }
							//nine
							for (int k = 0; k < 6; k++) {
								if (!input[nine].Contains(output[j][k])) {
									discovered = false;
								}
							}
							if (discovered) {
								part2 += 9*(int) Math.Pow(10,output.Length-1-j);
								break;
							}else { discovered = true; }
							break;
						//three, two, five
						case 5:
							//three
							for (int k = 0; k < 5; k++) {
								if (!input[three].Contains(output[j][k])) {
									discovered = false;
								}
							}
							if (discovered) {
								part2 += 3*(int) Math.Pow(10,output.Length-1-j);
								break;
							} else { discovered = true; }
							//two
							for (int k = 0; k < 5; k++) {
								if (!input[two].Contains(output[j][k])) {
									discovered = false;
								}
							}
							if (discovered) {
								part2 += 2*(int) Math.Pow(10,output.Length-1-j);
								break;
							} else { discovered = true; }
							//five
							for (int k = 0; k < 5; k++) {
								if (!input[five].Contains(output[j][k])) {
									discovered = false;
								}
							}
							if (discovered) {
								part2 += 5*(int) Math.Pow(10,output.Length-1-j);
								break;
							}
							break;
					}
				}
			}
			Console.WriteLine(part1 + "\n" + part2);
		}
	}
}