namespace GroupTerminal.Models;

public class Terminal
{
  public int Id { get; set; }
  public string? Brand { get; set; }
  public int TerminalId { get; set; }
  public DateTime Date { get; set; }
  public decimal Amount { get; set; }
}