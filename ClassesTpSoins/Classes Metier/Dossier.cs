// <copyright file="Dossier.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// classe Dossier.
    /// </summary>
    public class Dossier
    {
        private string nomPatient;
        private string prenomPatient;
        private DateTime dateDeNaissancePatient;
        private List<Prestation> mesPrestations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nomPatient">nom du patient.</param>
        /// <param name="prenomPatient">prenom du patient.</param>
        /// <param name="dateDeNaissance">date de naissance.</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance)
        {
            this.nomPatient = nomPatient;
            this.prenomPatient = prenomPatient;
            this.dateDeNaissancePatient = dateDeNaissance;
            this.mesPrestations = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// constructeur surchargé.
        /// Il comprend en plus un objet de la classe Prestation à rajouter dans la collection mesPrestations.
        /// </summary>
        /// <param name="nomPatient">nom du patient.</param>
        /// <param name="prenomPatient">prenom du patient.</param>
        /// <param name="dateDeNaissance">date de naissance du patient au format JJ/MM/AAAA.</param>
        /// <param name="unePrestation">objet de la classe Prestation à rajouter.</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, Prestation unePrestation)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            this.mesPrestations.Add(unePrestation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// constructeur surchargé
        /// Il comprend un onbjet Collection de Prestation.
        /// Il faudra affecter cette Collection à l'objet mesPrestations.
        /// </summary>
        /// <param name="nomPatient">nom du patient.</param>
        /// <param name="prenomPatient">prenom du patient.</param>
        /// <param name="dateDeNaissance">date de naissance du patient au format JJ/MM/AAAA.</param>
        /// <param name="desPrestations">List de parestaion.</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, List<Prestation> desPrestations)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            this.mesPrestations = desPrestations;
        }

        /// <summary>
        /// gets NomPatient.
        /// </summary>
        public string NomPatient
        {
            get
            {
                return this.nomPatient;
            }
        }

        /// <summary>
        /// Gets ¨PrenomPatient.
        /// </summary>
        public string PrenomPatient
        {
            get
            {
                return this.prenomPatient;
            }
        }

        /// <summary>
        /// Gets or sets DateNaissancePatient.
        /// </summary>
        public DateTime DateDeNaissancePatient
        {
            get
            {
                return this.dateDeNaissancePatient;
            }

            set
            {
                this.dateDeNaissancePatient = value;
            }
        }

        /// <summary>
        /// Gets List.<Prestation> MesPrestations
        /// </summary>
        internal List<Prestation> MesPrestations
        {
            get
            {
                return this.mesPrestations;
            }
        }

        /// <summary>
        ///    Ajoute un objet de la classe Prestation à la collection mesPrestations
        /// à noter qu'il faudra construire cet objet à partir des paramètres fournis.
        /// </summary>
        /// <param name="unLibelle">libellé de la prestation.</param>
        /// <param name="uneDateHeure">date et heure de la prestation.</param>
        /// <param name="unIntervenant">objet de la classe Intervenant, celui qui a fait la prestation.</param>
        public void AjoutePrestation(string unLibelle, DateTime uneDateHeure, Intervenant unIntervenant)
        {
            this.mesPrestations.Add(new Prestation(unLibelle, uneDateHeure, unIntervenant));
        }

        /// <summary>
        /// retourne le npmbre de prestations du dossier effectuées
        /// par un intervenant externe.
        /// </summary>
        /// <returns>entier représentatnt le nb de prestations externes du dossier.</returns>
        public short GetNbPrestationsExternes()
        {
            short nb = 0;
            foreach (Prestation unePrestation in this.mesPrestations)
            {
                if (unePrestation.UnIntervenant is IntervenantExterne)
                {
                    nb++;
                }
            }

            return nb;
        }

        /// <summary>
        /// Retourne le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        /// le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins.
        /// une prestation a été réalisée.
        /// On crée une collection de type LIST qui va contenir les dates de soins. On choisit LIST plutôt que Collection
        /// car LIST possède la méthode Contains qui va nous éviter d'écrire nous même la recherche de date existante dans la collection.
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation.</returns>
        public int GetNbJoursSoins()
        {
            List<DateTime> lesDates = new List<DateTime>();
            foreach (Prestation unePrestation in this.mesPrestations)
            {
                if (!lesDates.Contains(unePrestation.DateHeureSoin.Date))
                {
                    lesDates.Add(unePrestation.DateHeureSoin.Date);
                }
            }

            return lesDates.Count;
        }

        /// <summary>
        /// Retourne aussi le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins une prestation a été réalisée.
        /// On va utiliser un delegate qui va se charger de retourner si deux dates de prestations sont égales ou non.
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation.</returns>
        public int GetNbJoursSoinsV2()
        {
            List<DateTime> lesDates = new List<DateTime>();
            if (this.mesPrestations.Count == 0)
            { // pas de prestation
                return 0;
            }
            else
            {
                // il faut trier les prestations par date de soin
                this.mesPrestations.Sort(delegate(Prestation prestation1, Prestation prestation2)
                {
                    return prestation1.DateHeureSoin.Date.CompareTo(prestation2.DateHeureSoin.Date);
                });
                Prestation oldPrestation = this.mesPrestations[0];
                int nb = 1;
                for (int i = 0; i < this.mesPrestations.Count; i++)
                {
                    if (this.mesPrestations[i].CompareTo(oldPrestation) != 0)
                    {
                        nb++;
                        oldPrestation = this.mesPrestations[i];
                    }
                }

                return nb;
            }
        }
    }
}
