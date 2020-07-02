using DigitalMenu.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DigitalMenu.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();

            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);//conexao do banco

            _conexao.CreateTable<Tables>();
            _conexao.CreateTable<Token>();
        }

        //Consultas Token
        public bool ConsultaToken(string secret)
        {
            return _conexao.Table<Token>().Where(c => c.Secret == secret).Any();
        }
        public bool TokenExiste()
        {
            return _conexao.Table<Token>().Any();
        }
        public void CreateToken(Token token)
        {
            _conexao.Insert(token);
        }

        //Consultas Tables
        public List<Tables> ListTables()
        {
            return _conexao.Table<Tables>().ToList();
        }
        public bool TablesExist()
        {
            return _conexao.Table<Tables>().Any();
        }
        public void DeleteTables()
        {
            _conexao.Table<Tables>().Delete(x => x.Id != null);
        }
        public void CreateTables(List<Tables> tables)
        {
            _conexao.InsertAll(tables);
        }
        public void CreateTable(Tables table)
        {
            _conexao.Insert(table);
        }
        public void UpdateTable(Tables tables)
        {
            _conexao.Update(tables);
        }
        public int IdTable()
        {
            return _conexao.Table<Tables>().Where(c => c.Active == true).Select(c => c.Number).FirstOrDefault();
        }
        public Tables Table()
        {
            return _conexao.Table<Tables>().FirstOrDefault(c => c.Active == true);
        }

        /// <summary>
        /// //////////////////
        /// </summary>
        /// <returns></returns>
        public List<Tables> Consultar()
        {
            return _conexao.Table<Tables>().ToList();
        }
        public List<Tables> Pesquisa(string palavra)
        {
            return _conexao.Table<Tables>().Where(a => a.Active == true).ToList();
        }
        public Tables ObterVagaId(int id)
        {
            return _conexao.Table<Tables>().Where(a => a.Id == id).FirstOrDefault();
        }
        public void Cadastro(Tables vaga)
        {
            _conexao.Insert(vaga);
        }
        public void Atualizacao(Tables vaga)
        {
            _conexao.Update(vaga);
        }
        public void Exclusao(Tables vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
