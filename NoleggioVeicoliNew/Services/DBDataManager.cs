using Microsoft.EntityFrameworkCore;
using NoleggioVeicoliNew.domain;
using NoleggioVeicoliNew.interfaces;
using NoleggioVeicoliNew.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoliNew.services
{
    public class DBDataManager(NoleggioDbContext db) : IDataSourceDB
    {
        private readonly NoleggioDbContext _db = db;

        public void AddVeicolo(Veicolo veicolo)
        {
            var entity = ToEntity(veicolo);
            _db.Veicolis.Add(entity);
            _db.SaveChanges();
        }

        public void AddCliente(Cliente cliente)
        {
            var entity = ToEntity(cliente);
            _db.Clientis.Add(entity);
            _db.SaveChanges();
        }

        public void AddNoleggio(Noleggio noleggio)
        {
            var entity = ToEntity(noleggio);
            _db.Noleggis.Add(entity);
            _db.SaveChanges();
        }

        public void AddListVeicoli(List<Veicolo> veicoli)
        {
            var entities = veicoli.Select(ToEntity).ToList();
            _db.Veicolis.AddRange(entities);
            _db.SaveChanges();
        }

        public void AddListClienti(List<Cliente> clienti)
        {
            var entities = clienti.Select(ToEntity).ToList();
            _db.Clientis.AddRange(entities);
            _db.SaveChanges();
        }

        public List<Veicolo> GetAllVeicoli()
        {
            var list = _db.Veicolis
                          .ToList()
                          .Select(ToDto)
                          .ToList();
            return list;
        }

        public List<Cliente> GetAllClienti()
        {
            return _db.Clientis
                      .OrderBy(c => c.Nome)
                      .ToList()
                      .Select(ToDto)
                      .ToList();
        }

        public List<Noleggio> GetAllNoleggi()
        {
            return _db.Noleggis
                      .Include(n => n.IdClienteNavigation)
                      .Include(n => n.IdVeicoloNavigation)
                      .OrderByDescending(n => n.DataInizio)
                      .ToList()
                      .Select(ToDto)
                      .ToList();
        }

        public Veicolo? GetVeicoliById(Guid id)
        {
            var e = _db.Veicolis.FirstOrDefault(v => v.Id == id);
            return e is null ? null : ToDto(e);
        }

        public Cliente? GetClientiById(Guid id)
        {
            var e = _db.Clientis.FirstOrDefault(c => c.Id == id);
            return e is null ? null : ToDto(e);
        }

        public Noleggio? GetNoleggiById(Guid id)
        {
            var e = _db.Noleggis
                       .Include(n => n.IdClienteNavigation)
                       .Include(n => n.IdVeicoloNavigation)
                       .FirstOrDefault(n => n.Id == id);

            return e is null ? null : ToDto(e);
        }

        public List<Noleggio> GetNoleggiByData(DateTime data)
        {
            var entities = _db.Noleggis
                      .Include(n => n.IdClienteNavigation)
                      .Include(n => n.IdVeicoloNavigation)
                      .Where(n => n.DataInizio.Date == data.Date)
                      .OrderBy(n => n.DataInizio).ToList();

            var dtos = entities.Select(ToDto).ToList();
            return dtos;
        }

        public void UpdateNoleggio(Noleggio nl)
        {
            var noleggio = _db.Noleggis.FirstOrDefault(x => x.Id == nl.Id);
            if (noleggio is null)
                throw new InvalidOperationException("Noleggio non trovato.");

            noleggio.IdCliente = nl.Cliente.Id;
            noleggio.IdVeicolo = nl.Veicolo.Id;
            noleggio.DataInizio = nl.DataInizio;
            noleggio.DurataGiorni = (int)nl.DurataGiorni;

            _db.SaveChanges();
        }

        /* =========================================================
        * METODI PRIVATI DI UTILITY
        * ========================================================= */

        #region MAPPING VEICOLO
        private static Veicoli ToEntity(Veicolo dto)
        {
            return dto switch
            {
                models.Auto autoDto => new domain.Auto
                {
                    Id = autoDto.Id,
                    Targa = autoDto.Targa,
                    Modello = autoDto.Modello,
                    TariffaGiornaliera = autoDto.TariffaGiornaliera,
                    Noleggiato = autoDto.Noleggiato,
                    NumeroPorte = (byte)autoDto.NumeroPorte,
                    IsSportiva = autoDto.IsSportiva
                },
                models.Moto mm => new domain.Moto
                {
                    Id = mm.Id,
                    Targa = mm.Targa,
                    Modello = mm.Modello,
                    TariffaGiornaliera = mm.TariffaGiornaliera,
                    Noleggiato = mm.Noleggiato,
                    Cilindrata = mm.Cilindrata
                },
                models.Furgone mf => new domain.Furgoni
                {
                    Id = mf.Id,
                    Targa = mf.Targa,
                    Modello = mf.Modello,
                    TariffaGiornaliera = mf.TariffaGiornaliera,
                    Noleggiato = mf.Noleggiato,
                    CapacitaCaricoKg = mf.CapacitaCaricoKg
                },
                _ => throw new InvalidOperationException("Tipo di veicolo non supportato."),
            };
        }

        private static Veicolo ToDto(Veicoli dv)
        {
            // usa OfType con cast runtime per individuare la derivata
            if (dv is domain.Auto da)
            {
                return new models.Auto(da.Id, da.Targa, da.Modello, (double)da.TariffaGiornaliera, da.NumeroPorte, da.IsSportiva, da.Noleggiato);
            }
            else if (dv is domain.Moto dm)
            {
                return new models.Moto(dm.Id, dm.Targa, dm.Modello, (double)dm.TariffaGiornaliera, dm.Cilindrata, dm.Noleggiato);
            }
            else if (dv is domain.Furgoni df)
            {
                return new models.Furgone(df.Id, df.Targa, df.Modello, (double)df.TariffaGiornaliera, (double)df.CapacitaCaricoKg, df.Noleggiato);
            }
            else
            {
                throw new InvalidOperationException("Tipo di veicolo non supportato.");
            }
        }
        #endregion

        #region MAPPING CLIENTE
        private domain.Clienti ToEntity(Cliente mc)
        {
            return new domain.Clienti
            {
                Id = mc.Id,
                Nome = mc.Nome,
                CodiceCliente = mc.CodiceCliente,
                TipoPatente = MapPatenteToInt(mc.Patente)
            };
        }

        private Cliente ToDto(domain.Clienti dc)
        {
            return new Cliente(dc.Id, dc.Nome, dc.CodiceCliente, MapPatenteToEnum(dc.TipoPatente));
        }
        #endregion

        #region MAPPING TIPO PATENTE
        private static int MapPatenteToInt(TipoPatente p) => p switch
        {
            TipoPatente.A => 1,
            TipoPatente.B => 2,
            TipoPatente.C => 3,
            _ => throw new InvalidOperationException("Tipo di patente non supportato."),
        };

        private static TipoPatente MapPatenteToEnum(int id) => id switch
        {
            1 => TipoPatente.A,
            2 => TipoPatente.B,
            3 => TipoPatente.C,
            _ => throw new InvalidOperationException("Tipo di patente non supportato."),
        };
        #endregion 

        #region MAPPING NOLEGGIO
        private domain.Noleggi ToEntity(Noleggio mn)
        {
            return new Noleggi
            {
                Id = mn.Id,
                IdCliente = mn.Cliente.Id,
                IdVeicolo = mn.Veicolo.Id,
                DataInizio = mn.DataInizio,
                DurataGiorni = (int)mn.DurataGiorni
            };
        }

        private Noleggio ToDto(Noleggi dn)
        {
            var cliente = ToDto(dn.IdClienteNavigation);
            var veicolo = ToDto(dn.IdVeicoloNavigation);
            return new Noleggio(dn.Id, veicolo, cliente, (int)dn.DurataGiorni, dn.DataInizio);
        }
        #endregion
    }
}
