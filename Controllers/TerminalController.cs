using System;
using GroupTerminal.Models;
using GroupTerminal.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroupTerminal.Controllers;

[ApiController]
[Route("[controller]")]
public class TerminalController : ControllerBase
{
  public TerminalController()
  { }
  // GET all action
  [HttpGet]
  public ActionResult<List<Terminal>> GetAll() =>
      TerminalService.GetAll();
  // GET by Id action
  [HttpGet("{id}")]
  public ActionResult<Terminal> Get(int id)
  {
    var terminal = TerminalService.Get(id);

    if (terminal == null)
      return NotFound();

    return terminal;
  }

  // POST action
  [HttpPost]
  public IActionResult Create(Terminal terminal)
  {
    TerminalService.Add(terminal);
    return CreatedAtAction(nameof(Get), new { id = terminal.Id }, terminal);
  }

  // PUT action
  [HttpPut("{id}")]
  public IActionResult Update(int id, Terminal terminal)
  {
    if (id != terminal.Id)
      return BadRequest();

    var existingTerminal = TerminalService.Get(id);
    if (existingTerminal is null)
      return NotFound();

    TerminalService.Update(terminal);

    return NoContent();
  }

  // DELETE action
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var terminal = TerminalService.Get(id);

    if (terminal is null)
      return NotFound();

    TerminalService.Delete(id);

    return NoContent();
  }
}

