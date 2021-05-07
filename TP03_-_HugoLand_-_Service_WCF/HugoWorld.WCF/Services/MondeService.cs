﻿using HugoWorld_WCF.DTOs;
using HugoWorld_WCF.Models;
using System.Collections.Generic;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IMondeService {

        public List<TileImport> GetChunk(int[] TopLeft, int[] BotRight, MondeDTO p_world)
        {
            int BotRightX = BotRight[0];
            int BotRightY = BotRight[1];

            int TopLeftX = TopLeft[0];
            int TopLeftY = TopLeft[1];

            List<TileImport> objects = new List<TileImport>();

            using (HugoLandContext dbcontext = new HugoLandContext())
            {
                Monde m = dbcontext.Mondes.Find(p_world.Id);

                foreach (ObjetMondeDTO o in
                dbcontext.ObjetMondes.Where(obj => obj.x >= TopLeftX && obj.x <= BotRightX && obj.y >= TopLeftY && obj.y <= BotRightY && obj.MondeId == m.Id)
                    .Select(ob => new ObjetMondeDTO()
                    {
                        Id = ob.Id,
                        x = ob.x,
                        y = ob.y,
                        Description = ob.Description,
                        MondeId = ob.MondeId,
                        ImageId = ob.ImageId,
                        IsBlock = ob.IsBlock
                    }).ToList())
                    objects.Add(TileImport.ObjetMondeToTile(o));

                foreach (ItemDTO i in
                dbcontext.Items.Where(obj => obj.x >= TopLeftX && obj.x <= BotRightX && obj.y >= TopLeftY && obj.y <= BotRightY && obj.MondeId == m.Id)
                .Select(it => new ItemDTO()
                {
                    Id = it.Id,
                    Nom = it.Nom,
                    Description = it.Description,
                    x = it.x,
                    y = it.y,
                    MondeId = it.MondeId,
                    IdHero = it.IdHero,
                    ImageId = it.ImageId,
                    RowVersion = it.RowVersion
                }).ToList())
                    objects.Add(TileImport.ItemToTile(i));

                foreach (MonstreDTO o in
                dbcontext.Monstres.Where(obj => obj.x >= TopLeftX && obj.x <= BotRightX && obj.y >= TopLeftY && obj.y <= BotRightY && obj.MondeId == m.Id)
                    .Select(mo => new MonstreDTO()
                    {
                        Id = mo.Id,
                        Nom = mo.Nom,
                        x = mo.x,
                        y = mo.y,
                        StatPV = mo.StatPV,
                        StatDmgMin = mo.StatDmgMin,
                        StatDmgMax = mo.StatDmgMax,
                        MondeId = mo.MondeId,
                        ImageId = mo.ImageId
                    }).ToList())
                    objects.Add(TileImport.MonstreToTile(o));

                return objects;
            }
        }

        public List<MondeDTO> GetMondeDTOs()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                return dbContext.Mondes.ToList().Select(m => new MondeDTO(m)).ToList();
            }
        }

        public MondeDTO GetWorldByHero(HeroDTO p_Hero)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                Monde m = dbContext.Mondes.FirstOrDefault(x => x.Id == p_Hero.MondeId);
                if (m != null)
                {
                    return new MondeDTO()
                    {
                        Id = m.Id,
                        Description = m.Description,
                        LimiteX = m.LimiteX,
                        LimiteY = m.LimiteY
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public List<MondeDTO> GetWorldsForSelection()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                return dbContext.Mondes.Select(m => new MondeDTO()
                {
                    Id = m.Id,
                    Description = m.Description
                }).ToList();
            }
        }
    }
}