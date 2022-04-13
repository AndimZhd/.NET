namespace Program{
    public class HelpTable{
        private int argsLength;
        public int maxLength;
        public string[,] matrix;
        public HelpTable(string[] args) {
            argsLength = args.Length;
            maxLength = 4;
            matrix = new string[argsLength+1, argsLength+1];
            for(int i = 0; i<args.Length; i++) {
                maxLength = Math.Max(maxLength, args[i].Length);
                matrix[0, i+1] = args[i];
                matrix[i+1, 0] = args[i];
            }
            for(int i = 0; i<argsLength; i++) {
                for(int j = 0; j<argsLength; j++) {
                    int difference = i-j >=0 ? i-j : argsLength+i-j;
                    matrix[i+1,j+1] = difference <= argsLength/2 ? "WIN" : "LOSE";
                }
                matrix[i+1, i+1] = "DRAW";
            } 
            matrix[0,0] = "%%%";
        }

        public void printTable(){
            String str = "";
            for(int k = 0; k<(maxLength+1)*(argsLength+1)+1; k++) str+="-";
            System.Console.WriteLine(str);
            str = "";
            for(int i = 0; i<argsLength+1; i++) {
                str+="|";
                for(int j = 0; j<argsLength+1; j++) {
                    for(int k = 0; k<(maxLength-matrix[i, j].Length)/2; k++) str+=" ";
                    str+= matrix[i, j];
                    for(int k = 0; k < maxLength-matrix[i, j].Length-(maxLength-matrix[i, j].Length)/2; k++) str+=" ";
                    str+= "|";
                }
                System.Console.WriteLine(str);
                str = "";
                for(int k = 0; k<(maxLength+1)*(argsLength+1)+1; k++) str+="-";
                System.Console.WriteLine(str);
                str = "";
            }
        }
    }
}