namespace AdventOfCode{
    public partial class Day09{
        public static void D09(string file){
            String[] lines = File.ReadAllLines(file);
            int sum = 0;
            int[] basins = new int[3];
            basins[0]=1;
            basins[1]=1;
            basins[2]=1;

            for(int i = 0; i<lines.Length; i++) {
                for(int j = 0; j<lines[i].Length; j++) {
                    if((i==0||lines[i-1][j]>lines[i][j])
                        &&(i==lines.Length-1||lines[i+1][j]>lines[i][j])
                        &&(j==0||lines[i][j-1]>lines[i][j])
                        &&(j==lines[i].Length-1||lines[i][j+1]>lines[i][j])) {
                        sum+=(int)char.GetNumericValue(lines[i][j])+1;

                        char[,] touched = new char[lines.Length,lines[i].Length];
                        int basinSize = search(i,j,touched);
                        int temp;
                        if(basinSize>basins[0]) {
                            temp=basins[0];
                            basins[0]=basinSize;
                        } else { temp=basinSize; }

                        if(temp>basins[1]) {
                            basinSize=basins[1];
                            basins[1]=temp;
                        } else { basinSize=temp; }

                        if(basinSize>basins[2]) {
                            basins[2]=basinSize;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(basins[0]*basins[1]*basins[2]);

            int search(int x,int y,char[,] touched) {
                touched[x,y]=lines[x][y];
                int basin = 1;
                if(x>0&&(int)char.GetNumericValue(lines[x-1][y])!=9&&touched[x-1,y]!=lines[x-1][y]) {
                    basin+=search(x-1,y,touched);
                }
                if(x<lines.Length-1&&(int)char.GetNumericValue(lines[x+1][y])!=9&&touched[x+1,y]!=lines[x+1][y]) {
                    basin+=search(x+1,y,touched);
                }
                if(y>0&&(int)char.GetNumericValue(lines[x][y-1])!=9&&touched[x,y-1]!=lines[x][y-1]) {
                    basin+=search(x,y-1,touched);
                }
                if(y<lines[x].Length-1&&(int)char.GetNumericValue(lines[x][y+1])!=9&&touched[x,y+1]!=lines[x][y+1]) {
                    basin+=search(x,y+1,touched);
                }
                return basin;
            }
        }
    }
}