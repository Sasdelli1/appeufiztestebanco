using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace appeufiz.Data
{
    public class LocalDatabase
    {
            
        readonly SQLiteAsyncConnection database;

        public LocalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetLocalAsync()
        {
            //Get all notes.
            return database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetLocalAsync(int Id)
        {
            // Get a specific note.
            return database.Table<Item>()
                            .Where(i => i.Id == Id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLocalAsync(Item olocal)
        {
            if (olocal.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(olocal);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(olocal);
            }
        }

        public Task<int> DeleteLocalAsync(Item olocal)
        {
            // Delete a note.
            return database.DeleteAsync(olocal);
        }
    }
}

