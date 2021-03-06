using System.Collections.Generic;
using System.Linq;
using TP01_Library.Models;

namespace TP01_Library.Controllers {

    /// <summary>
    /// Auteur :        Vincent Pelland
    /// Description:    Gère les actions sur les ObjetMondes.
    /// Date :          2021-02-10
    /// </summary>
    public class ObjetMondeController {

        /// <summary>
        /// Auteur :        Vincent Pelland
        /// Description:    Créer un nouvel objetmonde d'un monde spécifique passé en paramètre.
        /// Date:           2021-02-10
        /// </summary>
        /// <param name="p_monde"></param>
        /// <param name="p_sDescription"></param>
        /// <param name="p_iPositionX"></param>
        /// <param name="p_iPositionY"></param>
        /// <param name="p_iTypeObjet"></param>
        public void AjouterObjetMonde(int p_iMondeId, string p_sDescription, int p_iPositionX, int p_iPositionY, int p_iTypeObjet, int p_imageId) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                dbContext.ObjetMondes.Add(new ObjetMonde() {
                    Description = p_sDescription,
                    x = p_iPositionX,
                    y = p_iPositionY,
                    TypeObjet = p_iTypeObjet,
                    MondeId = p_iMondeId,
                    ImageId = p_imageId
                });
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur :        Vincent Pelland
        /// Description:    Permet de supprimer un objetmonde spécifique à un monde passé en paramètre.
        /// Date :          2021-02-10
        /// </summary>
        /// <param name="p_monde"></param>
        /// <param name="p_objetMonde"></param>
        public void SupprimerObjetMonde(int p_iObjetMondeId) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                ObjetMonde objetMonde = dbContext.ObjetMondes.FirstOrDefault(x => x.Id == p_iObjetMondeId);

                dbContext.ObjetMondes.Remove(objetMonde);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur :        Vincent Pelland
        /// Description:    Permet de modifier la description
        ///                 d'un objetmonde spécifique à un monde, passé en paramètre.
        /// Date :          2021-02-10
        /// </summary>
        /// <param name="p_objetMonde"></param>
        /// <param name="p_monde"></param>
        /// <param name="p_newMonde"></param>
        /// <param name="p_sNouvelleDescription"></param>
        public void ModifierDescriptionObjetMonde(int p_iObjetMondeId, int p_iMondeId, int p_iNewMondeId = -1, string p_sNouvelleDescription = "") {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                ObjetMonde objetMonde = dbContext.ObjetMondes.FirstOrDefault(x => x.MondeId == p_iMondeId &&
                                                                             x.Id == p_iObjetMondeId);

                objetMonde.MondeId = p_iMondeId;

                if (p_iNewMondeId > 0) {
                    objetMonde.MondeId = p_iNewMondeId;
                }

                if (!string.IsNullOrEmpty(p_sNouvelleDescription)) {
                    objetMonde.Description = p_sNouvelleDescription;
                }

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur: Vincent Pelland
        /// Description: Retourne l'objetmonde par défaut, soit la tuile de gazon
        /// </summary>
        /// <returns></returns>
        public ObjetMonde GetObjetMondeDefault() {
            using (HugoLandContext context = new HugoLandContext()) {
                return context.ObjetMondes.FirstOrDefault(x => x.ImageId == 32);
            }
        }

        /// <summary>
        /// Auteur: Mathias Lavoie-Rivard
        /// Description: Permet d'ajouter les objetmondes et updater le monde en cours
        /// </summary>
        /// <param name="list"></param>
        public void AddRange(List<ObjetMonde> list) {
            using (HugoLandContext context = new HugoLandContext()) {
                context.ObjetMondes.AddRange(list);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Auteur: Mathias Lavoie-Rivard
        /// Description: Supprime les objetmondes du monde précédent avant la sauvegarde, pour faire place aux nouvelles listes
        /// </summary>
        /// <param name="id"></param>
        public void RemoveRange(int id) {
            using (HugoLandContext context = new HugoLandContext()) {
                //context.ObjetMondes.RemoveRange(context.ObjetMondes.Where(x => x.MondeId == id));
                //context.SaveChanges();

                //La requête SQL est beacoup plus rapide que le entity framework
                context.Database.ExecuteSqlCommand($"DELETE FROM dbo.ObjetMonde WHERE MondeId = {id}");
            }
        }
    }
}