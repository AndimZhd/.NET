namespace Program{
    class StoneScissorsPaper{

        private static bool isUserInputCorrect = false;

        private static void printUserOptions(string[] args){
            System.Console.WriteLine("Available moves:");
            for(int i = 0; i<args.Length; i++) {
                System.Console.WriteLine($"{i+1} - {args[i]}");
            }
            System.Console.WriteLine("0 - exit");
            System.Console.WriteLine("? - help");
        }
        public static void Main(string[] args) {
            if(args.Length < 3 || args.Length%2 == 0) {
                System.Console.WriteLine("Wrong input!");
                System.Console.WriteLine(args.Length<3? "Not enough parameters" : "Quantity of parameters must be even!");
                System.Console.WriteLine("Correct Example: dotnet run scissors stone paper");
                return;
            }

            HelpTable helpTable = new HelpTable(args);
            Rules rules = new Rules(args);
            var computerMove = rules.getComputerMove();
            HMAC hMAC = new HMAC(computerMove.Item1);
            hMAC.createHMACs();
            System.Console.WriteLine("HMAC: " + hMAC.getHMAC());
            string? userChoice = "";
            int userChoiceNumber = 0;


            while(!isUserInputCorrect) {
                printUserOptions(args);
                userChoice = System.Console.ReadLine();
                Int32.TryParse(userChoice, out userChoiceNumber);
                if(userChoice == "0" || userChoice == "exit") {return;}

                for(int i = 0; i<args.Length; i++) {
                    if(args[i] == userChoice || userChoiceNumber == i+1) {
                        isUserInputCorrect = true;
                        userChoiceNumber = i+1;
                        //System.Console.WriteLine($"{userChoice}, {userChoiceNumber}, {args[i]}, {i}");
                    }
                }
                if(userChoice == "?" || userChoice == "help") helpTable.printTable();
            }
            
            int result = rules.detectTheWinner(computerMove.Item2, userChoiceNumber);
            System.Console.WriteLine(result == 1 ? "You won!" : (result == 2 ? "Computer won!":"Draw!"));
            System.Console.WriteLine($"Computer move: {computerMove.Item1}");
            System.Console.WriteLine($"HMAC key: {hMAC.getKey()}");
        }

    }
}