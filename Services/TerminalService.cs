using GroupTerminal.Models;

namespace GroupTerminal.Services;

public static class TerminalService
{
  static List<Terminal> Terminals { get; }
  static int nextId = 3;
  static TerminalService()
  {
    Terminals = new List<Terminal>
    {
      new Terminal {Id = 1, Brand = "Visa", TerminalId = 99994321, Amount = 98, Date = DateTime.MaxValue},
      new Terminal {Id = 2, Brand = "MasterCard", TerminalId = 7874321, Amount = 138, Date = DateTime.MaxValue},
      new Terminal {Id = 3, Brand = "DKB", TerminalId = 4354321, Amount = 200, Date = DateTime.MaxValue},
      new Terminal {Id = 4, Brand = "Sparkasse", TerminalId = 7778321, Amount = 543, Date = DateTime.MaxValue},
    };
  }

  public static List<Terminal>? GetAll() => Terminals;
  public static Terminal? Get(int id) => Terminals?.FirstOrDefault(p => p.Id == id);
  public static void Add(Terminal terminal)
  {
    terminal.Id = nextId++;
    Terminals?.Add(terminal);
  }

  public static void Delete(int id)
  {
    var terminal = Get(id);
    if (terminal is null)
      return;
    Terminals.Remove(terminal);
  }

  // Update action
  public static void Update(Terminal terminal)
  {
    var index = Terminals.FindIndex(t => t.Id == terminal.Id);
    if (index == -1)
      return;

    Terminals[index] = terminal;
  }
}