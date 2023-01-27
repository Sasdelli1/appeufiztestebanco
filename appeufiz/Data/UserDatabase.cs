using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace appeufiz.Data
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Usuario>().Wait();
        }
        public Task<List<Usuario>> GetUsuarioAsync()
        {
            //Get all notes.
            return database.Table<Usuario>().ToListAsync();
        }

        public Task<Usuario> GetUsuarioAsync(int Id)
        {
            // Get a specific note.
            return database.Table<Usuario>()
                            .Where(i => i.Id == Id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUsuarioAsync(Usuario ousuario)
        {
            if (ousuario.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(ousuario);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(ousuario);
            }
        }

        public Task<int> DeleteUsuarioAsync(Usuario ousuario)
        {
            // Delete a note.
            return database.DeleteAsync(ousuario);
        }

    }
}
