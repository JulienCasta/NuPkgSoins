// <copyright file="Prestation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    using System;

    /// <summary>
    /// Class Prestation.
    /// </summary>
    public class Prestation
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant unIntervenant;

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// Constructeur.
        /// </summary>
        /// <param name="libelle">libelle.</param>
        /// <param name="uneDateHeure">date et heure de la prestation.</param>
        /// <param name="unIntervenant">un intervenant.</param>
        public Prestation(string libelle, DateTime uneDateHeure, Intervenant unIntervenant)
        {
            this.libelle = libelle;
            this.dateHeureSoin = uneDateHeure;
            this.unIntervenant = unIntervenant;
        }

        /// <summary>
        /// Gets property du libelle de la prestation
        /// (lecture seule).
        /// </summary>
        public string Libelle
        {
            get { return this.libelle; }
        }

        /// <summary>
        /// Gets property de la date des soins
        /// (lecture seule).
        /// </summary>
        public DateTime DateHeureSoin
        {
            get { return this.dateHeureSoin; }
        }

        /// <summary>
        /// Gets property de l'objet intervenant ayant réalisé la prestation
        /// (lecture seule).
        /// </summary>
        public Intervenant UnIntervenant
        {
            get { return this.unIntervenant; }
        }

        /// <summary>
        /// methode heuresoin.
        /// </summary>
        /// <returns>heure du soin.</returns>
        public string HeureSoin()
        {
            return this.DateHeureSoin.Hour + "h" + this.DateHeureSoin.Minute + " - " + this.DateHeureSoin.ToShortTimeString();
        }

        /// <summary>
        /// fonction qui compare 2 dates au format DateHeure
        /// Attention ici, on ne compare que les dates.
        /// 2 dates seront égales si leur JJ/MM/AAAA  sont égaux, quelle que soit l'heure.
        /// </summary>
        /// <param name="unePrestation">une prestation.</param>
        /// <returns>
        ///     0 les dates sont égales
        ///     1 si la date de la prestation courante est postérieure à la date de la prestation unePrestation
        ///     -1 si la date de la prestation courante est antérieure à la date de la prestation unePrestation.
        ///
        /// </returns>
        public int CompareTo(Prestation unePrestation)
        {
            // if(this.DateHeureSoin.Date > unePrestation.DateHeureSoin.Date) {
            //    return 1;
            // }
            // else
            // {
            //    if (this.DateHeureSoin.Date == unePrestation.DateHeureSoin.Date)
            //    {
            //        return 0;
            //    }
            //    else
            //    {
            //        return -1;
            //    }
            // }
            // bien mieux
            return this.DateHeureSoin.Date.CompareTo(unePrestation.DateHeureSoin.Date);
        }

        /// <summary>
        /// methode qui convertit un objet de la classe en string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return this.libelle + " - " + this.dateHeureSoin.ToString();
        }

        /// <summary>
        /// Effectue la somme de 2 nombres.
        /// </summary>
        /// <param name="a">entier1 à additionner.</param>
        /// <param name="b">entier2 à additionner.</param>
        /// <returns>entier égal à la somme des deux entiers passés en paramètre.</returns>
        public int SommePourRien(int a, int b)
        {
            return a + b;
        }
    }
}
