// See https://aka.ms/new-console-template for more information
using ConsoleApp;

Console.WriteLine("Hello, World!");


Test test = new();
int result = test.Calc(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
Console.WriteLine(result);

int age = 5;
Console.WriteLine(age);

test.SetAge(ref age);
Console.WriteLine(age);

int age2;
test.SetAge2(out age2); 
Console.WriteLine(age2); 
