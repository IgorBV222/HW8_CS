using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

internal class Character
{
    public string characterName { get; set; }
    public int characterAge { get; set; }
    public Character(string name, int age)
    {
        characterName = name;
        characterAge = age;
    }
}

namespace HW8_CS
{
    delegate void output();
    internal class Program
    {
        static List<Character> Ask_N_Times()
        {
            Console.WriteLine("Ведите количество персонажей: ");
            int numberOfCharacters = int.Parse(Console.ReadLine());
            var ans = new List<Character>();
            for (int i = 0; i < numberOfCharacters; i++)
            {
                ans.Add(CreateCharacter());
            }
            return ans;
        }
        static Character CreateCharacter()
        {
            string name;
            int age = 0;
            Console.WriteLine("Ведите имя персонажа: ");
            name = Console.ReadLine();            
            do
            {
                try
                {
                    Console.WriteLine("Ведите возраст персонажа: ");
                    age = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Возраст введен не корректно!");
                }
            } while (age <= 0 || age > 120);
            var character = new Character(name, age);
            character.characterAge = age;
            character.characterName = name;
            return character;
        }
        static void ConsoleOutputCharacters()
        {
            var CharactersList = Ask_N_Times();
            foreach (Character character in CharactersList)
            {
                Console.WriteLine($"Имя персонажа {character.characterName}, " + $" возраст {character.characterAge}");
            }  
        }
        static void OutputToFormCharacters()
        {
            var CharactersList = Ask_N_Times();
            string output = string.Empty;
            foreach (Character character in CharactersList)
            {
                output += ($"Имя персонажа {character.characterName}, " + $" возраст {character.characterAge}\n");
                Console.WriteLine($"Имя персонажа {character.characterName}, " + $" возраст {character.characterAge}");
            }
            MessageBox.Show(output);
        }        
        static void Main(string[] args)
        {
            Console.WriteLine("Создать проект с использованием БД SQLite. Суть решаемой задачи:\n" +
                    "Пользователь вводит имя и возраст персонажа, введённые данные по окончанию ввода выводятся на экран и записываются в БД (методы складываются в делегат).\n" +
                    "Для решения поставленной задачи можно использовать консолькное приложение, можно использовать приложение Windows Forms.\r\n" +
                    "_________________________________________________________________________________\n");

            output myOutput;            
            myOutput = OutputToFormCharacters;
            myOutput.Invoke();           
        }
    }
}
