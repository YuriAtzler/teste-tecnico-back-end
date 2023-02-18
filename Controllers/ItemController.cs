using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemController : ControllerBase
  {

    private List<Item> Items()
    {
      List<Item> Items = new List<Item> {
            new Item{Name = "Tomates", Id = 0, Created_at = new DateTime(2022, 10, 10)}
        };

      Items.Add(new Item { Name = "Torta", Id = 1, Created_at = new DateTime(2023, 10, 10) });
      Items.Add(new Item { Name = "Laranja", Id = 2, Created_at = new DateTime(2023, 12, 12) });
      Items.Add(new Item { Name = "Carne", Id = 3, Created_at = new DateTime(2022, 12, 12) });

      return Items;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(Items());
    }

    [HttpPost]
    public IActionResult Post(Item item)
    {
      var items = Items();
      items.Add(item);
      return Ok(items);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var items = Items().Where(x => x.Id != id);
      return Ok(items);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Item item)
    {
      var itemSalvo = Items().Where(x => x.Id == id).FirstOrDefault();
      if (itemSalvo == null) return NotFound("Item não encontrado!");

      itemSalvo.Name = item.Name;
      var items = Items().Where(x => x.Id != id).ToList();
      items.Add(itemSalvo);

      return Ok(items);
    }
  }
}