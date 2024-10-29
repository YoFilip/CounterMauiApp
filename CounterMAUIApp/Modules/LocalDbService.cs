using SQLite;
using System.Threading.Tasks;

namespace CounterMAUIApp
{
    public class LocalDbService
    {
        private const string DB_NAME = "counter.db";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Counter>();
        }

        // Get all notes from the database
        public async Task<List<Counter>> GetNote()
        {
            return await _connection.Table<Counter>().ToListAsync();
        }

        // Get a note by its ID
        public async Task<Counter> GetById(int id)
        {
            return await _connection.Table<Counter>().Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        // Create a new note
        public async Task Create(Counter note)
        {
            await _connection.InsertAsync(note);
        }

        // Update an existing note
        public async Task Update(Counter note)
        {
            await _connection.UpdateAsync(note);
        }

        // Delete a note
        public async Task Delete(Counter note)
        {
            await _connection.DeleteAsync(note);
        }
    }

}
