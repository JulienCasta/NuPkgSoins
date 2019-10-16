// <copyright file="IntervenantExterne.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    /// <summary>
    /// class IntervenantExterne hérité de la class Intervenant.
    /// </summary>
    public class IntervenantExterne : Intervenant
    {
        private string specialite;
        private string adresse;
        private string tel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// </summary>
        /// <param name="nom">nom.</param>
        /// <param name="prenom">prenom.</param>
        /// <param name="specialite">specialite.</param>
        /// <param name="adresse">adresse.</param>
        /// <param name="tel">tel.</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel)
            : base(nom, prenom)
        {
            this.specialite = specialite;
            this.adresse = adresse;
            this.tel = tel;
        }

        /// <summary>
        /// Gets specialite.
        /// </summary>
        public string Specialite
        {
            get { return this.specialite; }
        }

        /// <summary>
        /// Gets adresse.
        /// </summary>
        public string Adresse
        {
            get { return this.adresse; }
        }

        /// <summary>
        /// Gets tel.
        /// </summary>
        public string Tel
        {
            get { return this.tel; }
        }

        /// <summary>
        /// methode permettant de réecrire une methode existante.
        /// </summary>
        /// <returns>les interventions.</returns>
        public new string AfficheIntervenantComplet()
        {
            return this.ToString() + this.SesInterventions();
        }

        /// <summary>
        /// methode permettant de réecrire une methode existante.
        /// </summary>
        /// <returns>les interventions.</returns>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.Specialite + "\n\t\t  " + this.Adresse + " - " + this.Tel;
        }
    }
}
