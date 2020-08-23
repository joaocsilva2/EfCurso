using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EfCurso.Models;
using EfCurso.Database;
using Microsoft.EntityFrameworkCore;

namespace EfCurso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;

        public HomeController(ApplicationDBContext database)
        {
            this.database = database;
        }


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public IActionResult Teste()
        {
            var listaCategorias = database.Categorias.ToList();

            listaCategorias.ForEach(categoria =>
            {

                Console.WriteLine("");

                Console.WriteLine(categoria.ToString());
            });

            return Content("teste");
        }

        public IActionResult CadastrarCategoria()
        {
            Categoria cat = new Categoria();
            cat.Nome = "Açougue";

            Categoria cat2 = new Categoria();
            cat2.Nome = "Mercearia";

            Categoria cat3 = new Categoria();
            cat3.Nome = "Padaria";

            database.Categorias.Add(cat);
            database.Categorias.Add(cat2);
            database.Categorias.Add(cat3);

            database.SaveChanges();

            return Content("Categorias");
        }

        public IActionResult Relacionamento()
        {
            //Produto p = new Produto();
            //p.Nome = "Doritos";
            //p.Categoria = database.Categorias.First(c => c.Id == 1);

            //Produto p1 = new Produto();
            //p1.Nome = "Frango";
            //p1.Categoria = database.Categorias.First(c => c.Id == 1);

            //Produto p2 = new Produto();
            //p2.Nome = "Bolo";
            //p2.Categoria = database.Categorias.First(c => c.Id == 2);

            //database.Add(p);
            //database.Add(p1);
            //database.Add(p2);

            //database.SaveChanges();

            //var listaDeProdutos = database.Produtos.Include(p => p.Categoria).ToList();

            //listaDeProdutos.ForEach(p =>
            //{
            //    Console.WriteLine(p.ToString());
            //});

            //Não utilizar Lazy Loading, deixa muito lento

            var listaDeProdutosDeUmaCategoria = database.Produtos.Include(p => p.Categoria).Where(p => p.Categoria.Id == 1).ToList();

            listaDeProdutosDeUmaCategoria.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });

            return Content("Relacionamento");
        }
    }
}
