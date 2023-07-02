using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private List<Item> _items;

        public ItemsController()
        {
            _items = new List<Item>();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return _items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = item.Name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _items.Remove(item);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Item item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }
            if (item.Name != null)
            {
                existingItem.Name = item.Name;
            }
            if (item.Description != null)
            {
                existingItem.Description = item.Description;
            }
            return NoContent();
        }
    }
}