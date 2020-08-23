using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EfCurso.Models;
using EfCurso.Database;

namespace EfCurso.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database;

        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(f => f.Id == id);
            return View("Cadastrar", funcionario);
        }
        
        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(f => f.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if(funcionario.Id == 0)
            {
                database.Funcionarios.Add(funcionario);
            }
            else
            {
                Funcionario funcionarioDoBanco = database.Funcionarios.First(f => f.Id == funcionario.Id);
                //Atualiza automaticamente o registro do banco, não precisa utilizar o metodo Update().
                funcionarioDoBanco.Nome = funcionario.Nome;
                funcionarioDoBanco.Cpf = funcionario.Cpf;
                funcionarioDoBanco.Salario = funcionario.Salario;
            }
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
