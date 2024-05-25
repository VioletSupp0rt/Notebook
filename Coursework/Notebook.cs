using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая

{
    class Notebook
    {
        static void Main(string[] args)
        {
            string fileName = "Andrii-Notes.txt";

            Console.WriteLine("Andrii Murashko Notebook");
            // Створимо список нотаток
            List<string> notes = new List<string>();
            // Функція для додавання нотатки
            void AddNote()
            {
                Console.Write("Type any text: ");
                Console.WriteLine(" ");
                string note = Console.ReadLine();
                notes.Add(note);
            }
            // Функція для відображення списку нотаток
            void ShowNotes()
            {
                foreach (var note in notes)
                {
                    Console.WriteLine(note);
                }
            }
            // Функція для пошуку нотатки за текстом
            void SearchNote()
            {
                Console.Write("Enter required text to search: ");
                string searchQuery = Console.ReadLine();
                foreach (var note in notes)
                {
                    if (note.Contains(searchQuery))
                    {
                        Console.WriteLine(note);
                    }
                }
            }
            // Функція для збереження нотаток у файл
            void SaveNotes()
            {
                string filePath = fileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var note in notes)
                    {
                        writer.WriteLine(note);
                    }
                }
                Console.WriteLine("Notes successfully save into file." + filePath);
            }
            // Функція для завантаження нотаток з файлу
            void LoadNotes()
            {
                string filePath = fileName;
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            notes.Add(line);
                        }
                    }
                    Console.WriteLine("The following notes are loaded from file: " + filePath);
                    Console.WriteLine(notes.ToString());
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }

            // Головний цикл програми
            while (true)
            {
                Console.WriteLine("1. Add note to the notebook.");
                Console.WriteLine("2. Show list of notes.");
                Console.WriteLine("3. Find notes by text pattern.");
                Console.WriteLine("4. Save notes to file.");
                Console.WriteLine("5. Load notes from file.");
                Console.WriteLine("6. Exit.");
                Console.WriteLine(" ");
                Console.Write("Make a choose from 1 to 5, or Enter 6 to exit: ");
 
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNote();
                        break;
                    case 2:
                        ShowNotes();
                        break;
                    case 3:
                        SearchNote();
                        break;
                    case 4:
                        SaveNotes();
                        break;
                    case 5:
                        LoadNotes();
                        break;
                    case 6:
                        notes.Clear();
                        return;
                    default:
                        Console.WriteLine("You did a wrong choose. Please choose any from 1 to 5, or type 6 to exit.");
                        break;
                }
            }
        }
    }
}