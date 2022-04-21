using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Tecinfor.Models;

namespace ATIVIDADE_04_PI.Controllers 
{
public class TecinforController : Controller
{
  public IActionResult Faleconosco()
         {
             return View();
         }public IActionResult Produtos()
         {
             return View();
         }public IActionResult Sejaassociado()
         {
             return View();
         }

public IActionResult Lista(){
   TecinforRepository tr = new TecinforRepository();
   List<Cliente> lista = tr.Listar();

   return View (lista);

 }
 
public IActionResult Excluir(int Id){
    TecinforRepository tr = new TecinforRepository();
    Cliente userCliente = tr.BuscarPorID(Id);

    if(userCliente.Id>0){
        tr.remover(userCliente);
    }else{
        ViewData["mensagem"] = "cliente nao encontrado";

    }
    return RedirectToAction("Lista");
}

public IActionResult Inserir(){
    return View();
}
[HttpPost]
  public IActionResult Inserir(Cliente novoTec){
TecinforRepository tr = new TecinforRepository();
tr.inserir(novoTec);

ViewData["Mensagem"] = "Cadastro do cliente realizado";
return View();
  }

public IActionResult Alterar(int Id){
    TecinforRepository tr = new TecinforRepository();
    Cliente ClienteEncontrado = tr.BuscarPorID(Id);

    return View(ClienteEncontrado);
}
      [HttpPost]
         public IActionResult Alterar (Cliente cliente){


           TecinforRepository tr = new TecinforRepository();
           tr.atualizar(cliente);

           return RedirectToAction ("Lista");
           
         }

    }
 }