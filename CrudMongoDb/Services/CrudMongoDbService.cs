using MongoDB.Driver;
using CrudMongoDb.Models;
using System.Collections.Generic;

namespace CrudMongoDb.Services
{
    public class CrudMongoDbService
    {
        private readonly IMongoCollection<Pessoa> _pessoa;

        public CrudMongoDbService(ICrudMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pessoa = database.GetCollection<Pessoa>(settings.CrudCollectionName);
        }

        public List<Pessoa> ListarPessoas() =>
            _pessoa.Find(pessoa => true).ToList();

        public Pessoa ObterPessoa(string id) =>
            _pessoa.Find(pessoa => pessoa.Id == id).FirstOrDefault();

        public void IncluirPessoa(Pessoa pessoa) =>
            _pessoa.InsertOne(pessoa);

        public void AlterarPessoa(string id, Pessoa pessoa) =>
            _pessoa.ReplaceOne(pessoa => pessoa.Id == id, pessoa);

        public void ExcluirPessoa(string id) =>
            _pessoa.DeleteOne(pessoa => pessoa.Id == id);
    }
}
