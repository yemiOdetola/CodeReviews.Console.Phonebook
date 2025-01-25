using Microsoft.EntityFrameworkCore;
using Phonebook.yemiodetola.Models;


namespace Phonebook.yemiOdetola;

public class ContactsRepository
{

  public async Task AddContact(Contact contact)
  {
    using (var db = new PhonebookContext())
    {
      try
      {
        db.Contacts.Add(contact);
        await db.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException($"Error adding contact: {ex.Message}");
      }
    }
  }

  public async Task<List<Contact>> GetContacts()
  {
    using (var db = new PhonebookContext())
    {
      return await db.Contacts
      .Include(c => c.Category)
      .ToListAsync();
    }
  }

  public async Task<Contact> GetContactByName(string name)
  {
    using (var db = new PhonebookContext())
    {
      var contact = await db.Contacts.FirstOrDefaultAsync(c => c.Name == name);
      if (contact == null)
      {
        throw new InvalidOperationException($"Contact with Name {name} not found.");
      }
      return contact;
    }
  }

  public async Task UpdateContact(Contact contact)
  {
    using (var db = new PhonebookContext())
    {
      db.Update(contact);
      await db.SaveChangesAsync();
    }
  }

  public async Task DeleteContact(string name)
  {
    using (var db = new PhonebookContext())
    {
      var contact = await GetContactByName(name);
      if (contact == null)
      {
        throw new InvalidOperationException($"Contact with Name {name} not found.");
      }
      db.Contacts.Remove(contact);
      await db.SaveChangesAsync();
    }
  }
  public async Task CreateCategory(Category category)
  {
    using (var db = new PhonebookContext())
    {
      try
      {
        db.Categories.Add(category);
        await db.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw new Exception($"Error creating category: {ex.Message}");
      }
    }
  }

  public async Task<List<Category>> GetCategories()
  {
    using (var db = new PhonebookContext())
    {
      return await db.Categories.ToListAsync();
    }
  }
}
