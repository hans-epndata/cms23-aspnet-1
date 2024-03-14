using System.Text.RegularExpressions;

string emailPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$";
Regex regex = new Regex(emailPattern);


while(true)
{
    Console.Clear();

    Console.Write("Adress: ");
    var email = Console.ReadLine()!;

    var isValid = regex.IsMatch(email);
    Console.WriteLine($"{email} är {(isValid ? "giltig" : "ogiltig")}.");

    Console.ReadKey();
}