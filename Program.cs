using System.Runtime.CompilerServices;
using System.IO;
using System;


namespace SameTest
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine(" 1 - Open File");
      Console.WriteLine(" 2 - Create new File");
      Console.WriteLine(" 0 - Exit");
      short option = short.Parse(Console.ReadLine() ?? string.Empty);

      switch (option)
      {
        case 0:
          System.Environment.Exit(0);
          break;
        case 1:
          Open();
          break;
        case 2:
          Edit();
          break;
        default:
          Console.WriteLine("Invalid Operation");
          break;
      }

    }

    static void Open()
    {
      Console.Clear();
      Console.WriteLine("Qual o caminho do arquivo? ");
      string path = Console.ReadLine() ?? string.Empty;

      if (path != null)
      {
        using (var file = new StreamReader(path))
        {
          string text = file.ReadToEnd();
          Console.WriteLine(text);
        }
      }
      Console.WriteLine();
      Console.ReadLine();
      Menu();
    }

    static void Edit()
    {
      Console.Clear();

      Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
      Console.WriteLine("--------------");
      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);
      Console.Write(text);
      Save(text);
      Console.ReadLine();
      Menu();

    }

    static void Save(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual camnho para salvar o arquivo?");
      var path = Console.ReadLine();

      if (path != null)
        using (var file = new StreamWriter(path))
        {
          file.Write(text);
        }

      Console.WriteLine($"Arquivo {path} salvo com sucesso!");
      Console.ReadLine();
      Menu();
    }
  }

}
