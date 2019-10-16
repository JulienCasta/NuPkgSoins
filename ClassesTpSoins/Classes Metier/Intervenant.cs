// <copyright file="Intervenant.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// class Intervenant.
    /// </summary>
    public class Intervenant
    {
        private Collection<Prestation> lesPrestations;
        private string nom;
        private string prenom;

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        public Intervenant(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.lesPrestations = new Collection<Prestation>();
        }



        /// <summary>
        /// Gets nom.
        /// </summary>
        public string Nom
        {
          get { return this.nom; }
        }

        /// <summary>
        /// Gets prenom.
        /// </summary>
        public string Prenom
        {
          get { return this.prenom; }
        }

        /// <summary>
        /// Gets or Sets list de LesPrestations.
        /// </summary>
        public Collection<Prestation> LesPrestations
        {
          get { return this.lesPrestations; }
          set { this.lesPrestations = value; }
        }

        /// <summary>
        /// Méthode déjà existante réecrite.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return "Intervenant : " + this.Nom + " - " + this.Prenom;
        }

        /// <summary>
        /// methode affichage d'un intervenant complet.
        /// </summary>
        /// <returns>les interventions.</returns>
        public virtual string AfficheIntervenantComplet()
        {
            return this.ToString() + this.SesInterventions();
        }

        /// <summary>
        /// methode qui ajoute une prestation dans la list LesPrestations.
        /// </summary>
        /// <param name="prestation">une prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.lesPrestations.Add(prestation);
        }

        /// <summary>
        /// methode qui prend chaque prestation dans la list LesPrestations et qui les ajoute dans une chaine.
        /// </summary>
        /// <returns>la chaine.</returns>
        protected string SesInterventions()
        {
            string chaine = " ";
            foreach (Prestation unePrestation in this.lesPrestations)
            {
                chaine += "\n\t" + unePrestation;
            }

            return chaine;
        }
    }
}
