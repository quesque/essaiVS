using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Cinema
{
    class Film
    {
        private String nom;
        /// <summary>
        /// l'attribut affiche sert à stocker le nom du fichier image du film
        /// </summary>
        private String affiche;

        /// <summary>
        /// stocke le nom du film en majuscule dans l'attribut film
        /// stocke le nom du fichier image dans affiche
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="affiche"></param>
        public Film(String nom, String affiche) {
            this.setNom(nom);
            this.affiche = affiche;
        }

        public String getNom() {
            return this.nom;
        }
        public String getAffiche() {
            return this.affiche;
        }

        /// <summary>
        /// stocke le nom du filme en majuscule
        /// </summary>
        /// <param name="nom"></param>
        public void setNom(String nom) {
            this.nom = nom.ToUpper();
        }

        public void setAffiche(String affiche) {
            this.affiche = affiche;
        }
        

    }
}
