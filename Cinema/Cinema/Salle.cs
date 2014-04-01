using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    public class Salle
    {
        private Film unFilm;
        /// <summary>
        /// nombre de places possible dans la salle
        /// </summary>
        private int nbPlace;
        /// <summary>
        /// prix d'une place à tarif normal
        /// </summary>
        private double prix;
        /// <summary>
        /// pourcentage de réduction pour passer du tarif normal au tarif réduit
        /// </summary>
        static private double pourcentageReduction=80;
        /// <summary>
        /// nombre de places vendues pour cette salle pour la prochaine séance
        /// au tarif normal
        /// </summary>
        private int nbPlaceTarifNormal;
        /// <summary>
        /// nombre de places vendues pour cette salle pour la prochaine séance
        /// au tarif réduit
        /// </summary>
        private int nbPlaceTarifReduit;


        /// <summary>
        /// initialise les attributs
        /// </summary>
        /// <param name="unFilm"></param>
        /// <param name="nbPlace"></param>
        /// <param name="prix"></param>
        public Salle(Film unFilm, int nbPlace, double prix) {
            this.unFilm = unFilm;
            this.nbPlace = nbPlace;
            this.prix = prix;
            nbPlaceTarifNormal = 0;
            nbPlaceTarifReduit = 0;
        }

        /// <summary>
        /// calcule et renvoie le nombre de places restant disponibles dans la salle
        /// </summary>
        /// <returns></returns>
        private int nbPlacesDisponibles() {
            int resultat = 0;
            resultat = this.nbPlace - this.nbPlaceTarifNormal - this.nbPlaceTarifReduit;
            return resultat;
        }

        /// <summary>
        /// Met à jour le nombre de places à tarif réduit vendu et
        /// </summary>
        /// <param name="nbPlaces">nombre de places à tarif réduit demandé</param>
        /// <returns>le prix à payer pour ces places</returns>
        private Double vendPlaceReduit(int nbPlaces) {
            Double resultat=0;
            this.nbPlaceTarifReduit = this.nbPlaceTarifReduit + nbPlaces;
            resultat = nbPlaces * prix * (1-pourcentageReduction/100);
            return resultat;
        }

        /// <summary>
        /// Met à jour le nombre de places à tarif normal vendu et
        /// </summary>
        /// <param name="nbPlaces">nombre de places à tarif normal demandé</param>
        /// <returns>le prix à payer pour ces places</returns>
        private Double vendPlaceNormal(int nbPlaces) {
            Double resultat = 0;
            this.nbPlaceTarifNormal = this.nbPlaceTarifNormal + nbPlaces;
            resultat = nbPlaces * prix ;
            return resultat;
        }

        /// <summary>
        /// Permet de vendre des billets pour la salle
        /// Dans le cas où le nombre de places est insuffisant, une exception est levée 
        /// dans le cas contraire, la méthode qui fait la mise à jour et le calcul est appelée
        /// </summary>
        /// <param name="nb">nombre de places souhaitées</param>
        /// <param name="tarifReduit">indique si une réduction est demandée</param>
        /// <returns>prix à payer sous forme d'une chaîne de caractères</returns>
        public String vendrePlaces(int nb, bool tarifReduit) {
            String resultat= string.Empty;
            if (nb <= this.nbPlacesDisponibles()){
                if (tarifReduit) {
                    resultat = this.vendPlaceReduit(nb).ToString();
                }
                else
                    resultat = this.vendPlaceNormal(nb).ToString();
            }
            else
                throw new Exception("Plus assez de places");
            return resultat;
        }

        /// <summary>
        /// Permet de remettre à zéro le nombre de places vendues
        /// lorsqu'une séance est terminée
        /// </summary>
        public void remiseAZero() {
            this.nbPlaceTarifNormal = 0;
            this.nbPlaceTarifReduit = 0;
        }

        /// <summary>
        /// Donne le chiffre d'affaires par salle
        /// </summary>
        /// <returns></returns>
        public double chiffreAffaires() {
            double resultat = 0;
            resultat = this.nbPlaceTarifNormal * this.prix + this.nbPlaceTarifReduit * this.prix * (1 - pourcentageReduction / 100);
            return resultat;
        }

        /// <summary>
        /// Donne le taux de remplissage de la salle (en pourcentage)
        /// </summary>
        /// <returns></returns>
        public double tauxRemplissage() {
            double resultat = 0;
            resultat = this.nbPlace * 100 / (this.nbPlaceTarifNormal + this.nbPlaceTarifReduit);
            return resultat;
        }

        /// <summary>
        /// renvoie toutes les informations de la salle
        /// </summary>
        /// <returns></returns>
        public String toString() {
            String resultat = String.Empty;
            resultat = "Nom du film : " + this.unFilm.getNom() + "\n";
           
            return resultat;
        }
    }
}
