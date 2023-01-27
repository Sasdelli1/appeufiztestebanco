using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appeufiz.Data
{
    public class EufizDatabase
    {
        readonly SQLiteAsyncConnection database;

        public EufizDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Lembrete>().Wait();
        }
        public Task<List<Lembrete>> GetLembreteAsync()
        {
            //Get all notes.
            return database.Table<Lembrete>().ToListAsync();
        }

        public Task<Lembrete> GetLembreteAsync(int Id)
        {
            // Get a specific note.
            return database.Table<Lembrete>()
                            .Where(i => i.Id == Id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLembreteAsync(Lembrete olembrete)
        {
            if (olembrete.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(olembrete);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(olembrete);
            }
        }

        public Task<int> DeleteLembreteAsync(Lembrete olembrete)
        {
            // Delete a note.
            return database.DeleteAsync(olembrete);
        }

        internal Task DeleteLocalAsync(Item olocal)
        {
            throw new NotImplementedException();
        }

        internal Task<Item> GetLocalAsync(int id)
        {
            throw new NotImplementedException();
        }

        internal Task SaveLocalAsync(Item olocal)
        {
            throw new NotImplementedException();
        }
    }

}


