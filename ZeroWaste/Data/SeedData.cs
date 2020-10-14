using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroWaste.Models;

namespace ZeroWaste.Data
{
    public static class SeedData
    {
        internal static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {

                var db = serviceScope.ServiceProvider.GetService<ZeroDbContext>();
            
                SeedFamilias(db);
                SeedInstituicoes(db);
                SeedPedidoRestaurante(db);
                SeedPedidoSupermercado(db);
                SeedProdSuper(db);
                SeedRefRestaurant(db);
                SeedRegras(db);
                SeedRestaurantes(db);
                SeedSupermercado(db);
                SeedTipos(db);
                SeedVoluntarios(db);

            }
        }

        private static void SeedRegras(ZeroDbContext db)
        {
            
        }

        private static void SeedPedidoSupermercado(ZeroDbContext db)
        {
            
        }

        private static void SeedPedidoRestaurante(ZeroDbContext db)
        {
            
        }

        private static void SeedRefRestaurant(ZeroDbContext db)
        {
            if (db.RefeicoesRestaurante.Any()) return;

       
            Restaurante mcdonalds = GetRestauranteCreatingIfNeed(db, "Mcdonalds");
            Restaurante grelhados = GetRestauranteCreatingIfNeed(db, "Grelhados");
            Restaurante restaurant123 = GetRestauranteCreatingIfNeed(db, "Restaurante123");



            db.RefeicoesRestaurante.AddRange(

                new RefeicoesRestaurante
                {
                    Nome = "Arroz de pato",
                    Quantidade = 10,
                    IDRestaurante = restaurant123.IDRestaurante

                },
                new RefeicoesRestaurante
                                {
             Nome = "batatas",
            Quantidade = 10,
            IDRestaurante = grelhados.IDRestaurante

          }
            );

            db.SaveChanges();

        }
        private static Restaurante GetRestauranteCreatingIfNeed(ZeroDbContext db, string name)
        {
            Restaurante restaurante = db.Restaurante.SingleOrDefault(e => e.Nome == name);

            if (restaurante == null)
            {
                restaurante = new Restaurante { Nome = name };
                db.Add(restaurante);
                db.SaveChanges();
            }

            return restaurante;
        }

        private static void SeedRestaurantes(ZeroDbContext db)
        {
            if (db.Restaurante.Any()) return;

            db.Restaurante.AddRange(
                new Restaurante
                {
                    Nome = "Mcdonalds",
                    Telefone = "936571245",
                    Email = "pingasodoce@guarda.com",
                    Morada = "Rua das 234234",
                },
                new Restaurante
                {
                    Nome = "Pizzaria",
                    Telefone = "936571245",
                    Email = "LIDasL@guarda.com",
                    Morada = "Rua das 234234",
                },
                new Restaurante
                {
                    Nome = "Grelhados",
                    Telefone = "936571245",
                    Email = "Continentase@guarda.com",
                    Morada = "Rua das 234234",
                },
                new Restaurante
                {
                    Nome = "Restaurante123",
                    Telefone = "936571245",
                    Email = "Auchasan@guarda.com",
                    Morada = "Rua das 234234",
                }
            );

            db.SaveChanges();

        }

        private static void SeedVoluntarios(ZeroDbContext db)
        {
            if (db.Voluntarios.Any()) return;

            db.Voluntarios.AddRange(
                new Voluntarios
                {
                    Nome = "Maria Santos",
                    Telefone = "936571245",
                    Email = "manuelsantos@guarda.com",
                    Morada = "Rua das neves",
                    DataNasc = new DateTime(1988, 5, 1),
                    NrTotalEntregas = 3,

                },

                  new Voluntarios
                  {
                      Nome = "joaquim Santos",
                      Telefone = "936571245",
                      Email = "manuelsantos@guarda.com",
                      Morada = "Rua das neves",
                      DataNasc = new DateTime(1988, 5, 1),
                      NrTotalEntregas = 3,
                  },
                    
                  new Voluntarios
                                   {
                 Nome = "Raul Santos",
                   Telefone = "936571245",
                       Email = "manuelsantos@guarda.com",
                          Morada = "Rua 1",
                      DataNasc = new DateTime(1988, 5, 1),
                      NrTotalEntregas = 3,
                                   },

                                 new Voluntarios
                                 {
                                     Nome = "Marco Santos",
                                     Telefone = "936571245",
                                     Email = "manuelsantos@guarda.com",
                                     Morada = "Rua das neves",
                                     DataNasc = new DateTime(1988, 5, 1),
                                     NrTotalEntregas = 3,
                                 },

                 new Voluntarios
                 {
                     Nome = "Rita Santos",
                     Telefone = "936571245",
                     Email = "manuelsantos@guarda.com",
                     Morada = "Rua das neves",
                     DataNasc = new DateTime(1988, 5, 1),
                     NrTotalEntregas = 3,
                 }

            );

            db.SaveChanges();

        }

        private static void SeedTipos(ZeroDbContext db)
        {
            if (db.Tipo.Any()) return;

            db.Tipo.AddRange(
                new Tipo { Nome = "Congelados" },
                new Tipo { Nome = "Fruta e legumes" },
                new Tipo { Nome = "Enlatados" },
                new Tipo { Nome = "Padaria" }
            );

            db.SaveChanges();
        }


        private static void SeedFamilias(ZeroDbContext db)
        {
            if (db.Familias.Any()) return;

            db.Familias.AddRange(
                new Familias
                {
                    Nome = "Maria Santos",
                    Telefone = "936571245",
                    Email = "manuelsantos@guarda.com",
                    Morada="Rua das neves",
                    Rendimento = 400,
                    NumeroPessoasAgregado=3,

                },

                  new Familias
                  {
                     Nome = "joaquim Santos",
                     Telefone = "936571245",
                        Email = "manuelsantos@guarda.com",
                        Morada = "Rua das neves",
                         Rendimento = 400,
                     NumeroPessoasAgregado = 3,
                  },
                                   new Familias
                  {
                     Nome = "Raul Santos",
                     Telefone = "936571245",
                        Email = "manuelsantos@guarda.com",
                        Morada = "Rua 1",
                         Rendimento = 400,
                     NumeroPessoasAgregado = 3,
                  },

                                 new Familias
                  {
                     Nome = "Marco Santos",
                     Telefone = "936571245",
                        Email = "manuelsantos@guarda.com",
                        Morada = "Rua das neves",
                         Rendimento = 400,
                     NumeroPessoasAgregado = 3,
                  },

                 new Familias
                 {
                     Nome = "Rita Santos",
                     Telefone = "936571245",
                     Email = "manuelsantos@guarda.com",
                     Morada = "Rua das neves",
                     Rendimento = 400,
                     NumeroPessoasAgregado = 3,
                 }

            );

            db.SaveChanges();
        }


        private static void SeedSupermercado(ZeroDbContext db)
        {
            if (db.Supermercado.Any()) return;

            db.Supermercado.AddRange(
                new Supermercado {
                    Nome = "Pingo doce",
                    Telefone = "936571245",
                    Email = "pingodoce@guarda.com",
                    Morada = "Rua das 234234",
                },
                new Supermercado
                {
                    Nome = "LIDL",
                    Telefone = "936571245",
                    Email = "LIDL@guarda.com",
                    Morada = "Rua das 234234",
                },
                new Supermercado
                {
                    Nome = "Continente",
                    Telefone = "936571245",
                    Email = "Continente@guarda.com",
                    Morada = "Rua das 234234",
                },
                new Supermercado
                {
                    Nome = "Auchan",
                    Telefone = "936571245",
                    Email = "Auchan@guarda.com",
                    Morada = "Rua das 234234",
                }
            );

            db.SaveChanges();
        }

        private static void SeedProdSuper(ZeroDbContext db)
        {
            if (db.ProdutosSupermercado.Any()) return;
            Tipo congelados = GetTipoCreatingIfNeed(db, "Congelados");
            Tipo Enlatados = GetTipoCreatingIfNeed(db, "Enlatados");
            Supermercado pingo = GetSuperCreatingIfNeed(db, "Pingo Doce");



            db.ProdutosSupermercado.AddRange(
                new ProdutosSupermercado { 
                    Nome = "Salmão",
                    Quantidade=50,
                    IDTipo=congelados.IDTipo,
                    IDSupermercado=pingo.IDSupermercado,
                                                    
                },
                new ProdutosSupermercado
                {
                    Nome = "Ervilhas",
                    Quantidade = 50,
                    IDTipo = congelados.IDTipo,
                    IDSupermercado = pingo.IDSupermercado,


                },
                new ProdutosSupermercado
                {
                    Nome = "Douradinhos",
                    Quantidade = 10,
                    IDTipo = congelados.IDTipo,
                    IDSupermercado = pingo.IDSupermercado,


                }
            );

            db.SaveChanges();
        }


        private static void SeedInstituicoes(ZeroDbContext db)
        {
            if (db.Instituicoes.Any()) return;

            db.Instituicoes.AddRange(
                new Instituicoes
                {
                    Nome = "dsfxcvxv",
                    Telefone = "936571245",
                    Email = "manuelsantos@guarda.com",
                    Morada = "Rua das neves",
                    NumeroPessoasAbrangidas = 400,
                    

                },

                  new Instituicoes
                  {
                      Nome = "jasdasdasdasds",
                      Telefone = "936571245",
                      Email = "manuelsantos@guarda.com",
                      Morada = "Rua das neves",
                      NumeroPessoasAbrangidas = 400,
                  },
                                   new Instituicoes
                                   {
                                       Nome = "Rasdsadad",
                                       Telefone = "936571245",
                                       Email = "manuelsantos@guarda.com",
                                       Morada = "Rua 1",
                                       NumeroPessoasAbrangidas = 400,
                                   },

               new Instituicoes
                    {
                   Nome = "Mqsdsadads",
               Telefone = "936571245",
                   Email = "manuelsantos@guarda.com",
                 Morada = "Rua das neves",
                 NumeroPessoasAbrangidas = 400,
                  },

                 new Instituicoes
                 {
                    Nome = "inst1",
                     Telefone = "936571245",
                     Email = "manuelsantos@guarda.com",
                     Morada = "Rua das neves",
                     NumeroPessoasAbrangidas = 400,
                 }

            );

            db.SaveChanges();
        }



        private static Tipo GetTipoCreatingIfNeed(ZeroDbContext db, string Nome)
        {
            Tipo tipo = db.Tipo.SingleOrDefault(e => e.Nome == Nome);

            if (tipo == null)
            {
                tipo = new Tipo { Nome = Nome };
                db.Add(tipo);
                db.SaveChanges();
            }

            return tipo;
        }


        private static Supermercado GetSuperCreatingIfNeed(ZeroDbContext db, string Nome)
        {
            Supermercado super = db.Supermercado.SingleOrDefault(e => e.Nome == Nome);

            if (super == null)
            {
                super = new Supermercado { Nome = Nome };
                db.Add(super);
                db.SaveChanges();
            }

            return super;
        }

    }


}
