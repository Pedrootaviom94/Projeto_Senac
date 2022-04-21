using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tecinfor.Models;

namespace ATIVIDADE_04_PI {

public class  TecinforRepository{
    
    private const string DadosConexao = "Database=Tecinfor; Data Source=localhost; User Id=root";

  public void inserir(Cliente novoTec){
   
   MySqlConnection Conexao = new MySqlConnection(DadosConexao);

    Conexao.Open();

    string Query = "INSERT INTO Cliente (Nome, Contato, Servico, Dataservico, Id) values (@Nome, @Contato, @Servico, @Dataservico, @Id)";

   MySqlCommand Comando = new MySqlCommand (Query, Conexao);

   Comando.Parameters.AddWithValue("@Nome", novoTec.Nome);
   Comando.Parameters.AddWithValue("@Contato", novoTec.Contato);
   Comando.Parameters.AddWithValue("@Servico", novoTec.Servico);
   Comando.Parameters.AddWithValue("@Dataservico", novoTec.DataServico);
   Comando.Parameters.AddWithValue("Id", novoTec.Id);

   Comando.ExecuteNonQuery();

   Conexao.Close();
  }


   public void atualizar(Cliente  userTec){
     MySqlConnection Conexao = new MySqlConnection(DadosConexao);
     Conexao.Open();

     string Query = "UPDATE Cliente SET Nome=@Nome, Contato=@Contato, Servico=@Servico, Dataservico=@Dataservico where Id = @Id";

     MySqlCommand Comando = new MySqlCommand (Query, Conexao);
     Comando.Parameters.AddWithValue("@Id", userTec.Id);
     Comando.Parameters.AddWithValue("@Nome", userTec.Nome);
     Comando.Parameters.AddWithValue("@Contato", userTec.Contato);
     Comando.Parameters.AddWithValue("@Servico",userTec.Servico);
     Comando.Parameters.AddWithValue("@Dataservico", userTec.DataServico);
   
      Comando.ExecuteNonQuery();

      Conexao.Close();

   }

   public void remover (Cliente userTec){
 
   MySqlConnection Conexao = new MySqlConnection(DadosConexao);

   Conexao.Open();
  
   string Query = "DELETE FROM Cliente where Id = @Id";
   MySqlCommand Comando = new MySqlCommand (Query, Conexao);

   Comando.Parameters.AddWithValue("@Id", userTec.Id);

   Comando.ExecuteNonQuery();
   Conexao.Close();

   }

   public Cliente BuscarPorID (int Id){
   MySqlConnection Conexao = new MySqlConnection(DadosConexao);
   Conexao.Open();

     Cliente ClienteEncontrado = new Cliente();

   string Query = "select * from Cliente where Id = @Id";

MySqlCommand Comando = new MySqlCommand (Query, Conexao);

Comando.Parameters.AddWithValue("@Id", Id);

MySqlDataReader reader = Comando.ExecuteReader();

if (reader.Read())
{
 ClienteEncontrado.Id = reader.GetInt32("Id");

 if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
 ClienteEncontrado.Nome = reader.GetString("Nome");

 if(!reader.IsDBNull(reader.GetOrdinal("Contato")))
  ClienteEncontrado.Contato = reader.GetString("Contato");

  if(!reader.IsDBNull(reader.GetOrdinal("Servico")))
  ClienteEncontrado.Servico = reader.GetString("Servico");

  ClienteEncontrado.DataServico = reader.GetDateTime("Dataservico");
}
 Conexao.Close();


return ClienteEncontrado;




   }


public List<Cliente> Listar(){
MySqlConnection Conexao = new MySqlConnection(DadosConexao);

Conexao.Open();

List<Cliente> ListaCliente = new List<Cliente>();

string Query = "Select * from Cliente";

MySqlCommand Comando = new MySqlCommand(Query, Conexao);

MySqlDataReader Reader = Comando.ExecuteReader();

while (Reader.Read())
{
  Cliente ClienteEncontrado = new Cliente();
  ClienteEncontrado.Id = Reader.GetInt32("Id");
  
   if(!Reader.IsDBNull(Reader.GetOrdinal("Nome"))){
     ClienteEncontrado.Nome = Reader.GetString("Nome");
   }

if (!Reader.IsDBNull(Reader.GetOrdinal("Contato")))
ClienteEncontrado.Contato = Reader.GetString("Contato");

if (!Reader.IsDBNull(Reader.GetOrdinal("Servico")))
ClienteEncontrado.Servico = Reader.GetString("Servico");

ClienteEncontrado.DataServico = Reader.GetDateTime("Dataservico");

ListaCliente.Add(ClienteEncontrado);

}
Conexao.Close();

return ListaCliente;



}

}

}
