using System.Collections.Generic;
using System.Linq;
using TP01_Library.Models;

namespace TP01_Library.Controllers {

    public class ItemController {

        /// <summary>
        /// Auteur: Mathias Lavoie-Rivard |
        /// Summary: Permet de créer un nouvel item. |
        /// Date: 2021-02-11
        /// </summary>
        /// <param name="p_nom"></param>
        /// <param name="p_description"></param>
        /// <param name="p_x"></param>
        /// <param name="p_y"></param>
        /// <param name="p_ImageID"></param>
        /// <param name="p_MondeID"></param>
        public void AjouterItems(string p_nom, string p_description, int p_x, int p_y, int p_ImageID, int p_MondeID) {
            using (HugoLandContext dbcontext = new HugoLandContext()) {
                dbcontext.Items.Add(new Item() {
                    Nom = p_nom,
                    Description = p_description,
                    x = p_x,
                    y = p_y,
                    MondeId = p_MondeID,
                    ImageId = p_ImageID
                });

                dbcontext.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur: Mathias Lavoie-Rivard |
        /// Summary: Permet de supprimer un item de la map et de l'ajouter dans l'inventaire d'un hero |
        /// Date: 2021-02-11
        /// </summary>
        /// <param name="p_Item"></param>
        /// <param name="p_CompteJoeur"></param>
        public void SupprimerItem(int p_iItemId, Hero p_Hero) {
            using (HugoLandContext dbcontext = new HugoLandContext()) {
                if (p_Hero != null) {
                    Item itemDelete = dbcontext.Items.FirstOrDefault(x => x.Id == p_iItemId);

                    itemDelete.x = null;
                    itemDelete.y = null;
                    itemDelete.IdHero = p_Hero.Id;
                    dbcontext.SaveChanges();
                } else {
                    Item itemDelete = dbcontext.Items.FirstOrDefault(x => x.Id == p_iItemId);
                    dbcontext.Items.Remove(itemDelete);
                }
            }
        }

        /// <summary>
        /// Auteur: Mathias Lavoie-Rivard
        /// Description: Permet d'ajouter les items et updater le monde en cours
        /// </summary>
        /// <param name="list"></param>
        public void AddRange(List<Item> list) {
            using (HugoLandContext context = new HugoLandContext()) {
                context.Items.AddRange(list);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur: Mathias Lavoie-Rivard
        /// Description: Supprime les items du monde précédent avant la sauvegarde, pour faire place aux nouvelles listes
        /// </summary>
        /// <param name="id"></param>
        public void RemoveRange(int id) {
            using (HugoLandContext context = new HugoLandContext()) {
                //context.Items.RemoveRange(context.Items.Where(x => x.MondeId == id));
                //context.SaveChanges();

                //La requête SQL est beacoup plus rapide que le entity framework
                context.Database.ExecuteSqlCommand($"DELETE FROM dbo.Item WHERE MondeId = {id}");
            }
        }
    }
}